using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApiForMSSQL.DAL;
using SignalRApiForMSSQL.Hubs;

namespace SignalRApiForMSSQL.Model
{
    public class VisitorService
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHub> _hubContext;
        private readonly IServiceScopeFactory _scopeFactory;

        public VisitorService(Context context, IHubContext<VisitorHub> hubContext, IServiceScopeFactory scopeFactory)
        {
            _context = context;
            _hubContext = hubContext;
            _scopeFactory = scopeFactory;
        }
        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }
        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();

            using var scope = _scopeFactory.CreateScope();
            var newService = scope.ServiceProvider.GetRequiredService<VisitorService>();
            var charts = newService.GetVisitorChartsList();
            await _hubContext.Clients.All.SendAsync("ReceiveVisitorList", charts);
        }

        public List<VisitorChart> GetVisitorChartsList()
        {
            var visitorCharts = new List<VisitorChart>();
            using var connection = _context.Database.GetDbConnection();
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "EXEC SignalRPivotTable";
            command.CommandType = System.Data.CommandType.Text;

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var chart = new VisitorChart
                {
                    VisitDate = reader.GetDateTime(0).ToShortDateString()
                };
                Enumerable.Range(1, 5).ToList().ForEach(x =>
                {
                    chart.Counts.Add(DBNull.Value.Equals(reader[x]) ? 0 : reader.GetInt32(x));
                });
                visitorCharts.Add(chart);
            }
            connection.Close();
            return visitorCharts;
        }


    }
}
