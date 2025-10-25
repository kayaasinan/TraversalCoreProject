using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalRApiForMSSQL.DAL;
using SignalRApiForMSSQL.Model;

namespace SignalRApiForMSSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController(VisitorService _visitorService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> CreateVisitor()
        {
            Random random = new Random();
            foreach (int x in Enumerable.Range(1, 10))
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        DailyVisitorCount = random.Next(100, 2000),
                        VisitDate = DateTime.Now.AddDays(x)
                    };
                    await _visitorService.SaveVisitor(newVisitor);
                    await Task.Delay(1000);
                }
            }
            return Ok("Ziyaretçiler eklendi");
        }
    }
}