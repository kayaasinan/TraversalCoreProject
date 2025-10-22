using BusinessLayer.Abstract.AbstractUOW;
using DTOLayer.DTOs.AccountDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public SelectList GetAccountSelectList()
        {
            var accounts = _accountService.TGetAll();
            return new SelectList(accounts, nameof(Account.AccountId), nameof(Account.Name));
        }
        public IActionResult Index()
        {
            ViewBag.SenderList = GetAccountSelectList();
            ViewBag.ReceiverList = GetAccountSelectList();
            return View();
        }
        [HttpPost]
        public IActionResult Index(AccountDto dto)
        {
            ViewBag.SenderList = GetAccountSelectList();
            ViewBag.ReceiverList = GetAccountSelectList();

            if (dto.SenderId == dto.ReceiverId)
            {
                ViewBag.Message = "Gönderen ve alıcı aynı hesap olamaz.";
                return View();
            }

            var valueSender = _accountService.TGetById(dto.SenderId);
            var valueReceiver = _accountService.TGetById(dto.ReceiverId);

            if (valueSender.Balance < dto.Amount)
            {
                ViewBag.Message = "Yetersiz bakiye.";
                return View();
            }

            valueSender.Balance -= dto.Amount;
            valueReceiver.Balance += dto.Amount;

            List<AccountDto> modifiedAccounts = new List<AccountDto>
             {
                 valueSender,
                 valueReceiver
             };

            _accountService.TMultiUpdate(modifiedAccounts);
            ViewBag.Message = "İşlem başarıyla gerçekleştirildi.";
            return View();
        }
    }
}
