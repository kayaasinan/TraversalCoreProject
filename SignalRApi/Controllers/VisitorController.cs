using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL;
using SignalRApi.Model;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController(VisitorService _visitorService) : ControllerBase
    {
        [HttpGet]
        public IActionResult CreateVisitor()
        {
            var rnd = new Random();
            Enumerable.Range(0, 10).ToList().ForEach(x =>
            {
                foreach(ECity city in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = city,
                        DailyVisitorCount = rnd.Next(100, 2000),
                        VisitDate = DateTime.UtcNow.AddDays(x)
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçiler başarılı bir şekilde eklendi");
        }
    }
}
