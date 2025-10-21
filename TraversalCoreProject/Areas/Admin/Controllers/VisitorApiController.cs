using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private HttpClient CreateClient()
        {
            return _httpClientFactory.CreateClient();
        }


        public async Task<IActionResult> Index()
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44325/api/Visitor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
        public IActionResult AddVisitor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVisitor(VisitorViewModel model)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44325/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "VisitorApi", new { area = "Admin" });

            return View();
        }
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44325/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "VisitorApi", new { area = "Admin" });

            return View();
        }
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44325/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<VisitorViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(VisitorViewModel model)
        {
            var client = CreateClient();
            var jsonData = JsonConvert.SerializeObject(model);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:44325/api/Visitor/{model.VisitorId}", content);
            if (responseMessage.IsSuccessStatusCode)
                return RedirectToAction("Index", "VisitorApi", new { area = "Admin" });

            return View();
        }
    }
}

