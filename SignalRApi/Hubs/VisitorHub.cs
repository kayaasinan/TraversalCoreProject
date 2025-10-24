using Microsoft.AspNetCore.SignalR;
using SignalRApi.Model;

namespace SignalRApi.Hubs
{
    public class VisitorHub(VisitorService _visitorService) : Hub
    {
        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList","bbb" /*_visitorService.GetVisitorChartsList()*/);
        }
    }
}
