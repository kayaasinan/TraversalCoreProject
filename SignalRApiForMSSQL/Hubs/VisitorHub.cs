using Microsoft.AspNetCore.SignalR;
using SignalRApiForMSSQL.DAL;
using SignalRApiForMSSQL.Model;

namespace SignalRApiForMSSQL.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public VisitorHub(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        public async Task GetVisitorList()
        {
            using var scope = _scopeFactory.CreateScope();
            var service = scope.ServiceProvider.GetRequiredService<VisitorService>();
            var list = service.GetVisitorChartsList();
            await Clients.All.SendAsync("ReceiveVisitorList", list);
        }
    }
}


