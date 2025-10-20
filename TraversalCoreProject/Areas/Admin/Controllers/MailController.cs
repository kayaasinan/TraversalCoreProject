using BusinessLayer.Abstract;
using DTOLayer.DTOs.MailDTOs;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MailController : Controller
    {
        private readonly IMailService _mailService;

        public MailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(MailRequestDTO mailRequestDTO)
        {
            _mailService.TSendMail(mailRequestDTO);
            ViewBag.Message = "Mail başarıyla gönderildi.";
            return View();
        }
    }
}
