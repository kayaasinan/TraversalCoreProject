using DTOLayer.DTOs.MailDTOs;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class AccountController(UserManager<AppUser> _userManager, IConfiguration _configuration) : Controller
    {
    
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Mail);
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var passwordResetTokenLink = Url.Action("ResetPassword", "Account", new
            {
                userId = user.Id,
                token = passwordResetToken
            }, HttpContext.Request.Scheme);


            var mailSettings = _configuration.GetSection("MailSettings");

            if (string.IsNullOrEmpty(mailSettings["Mail"]) || string.IsNullOrEmpty(mailSettings["Password"]))
                throw new Exception("MailSettings eksik veya hatalı yapılandırılmış!");

         
            string mail = mailSettings["Mail"]!;
            string displayName = mailSettings["DisplayName"]!;
            string password = mailSettings["Password"]!;
            string host = mailSettings["Host"]!;
            int port = int.Parse(mailSettings["Port"]!);
            bool enableSSL = bool.Parse(mailSettings["EnableSSL"]!);


            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(displayName, mail));
            mimeMessage.To.Add(new MailboxAddress("User", dto.Mail));
            mimeMessage.Subject = "Şifre Değişiklik Talebi";

            var bodyBuilder = new BodyBuilder
            {
                TextBody = passwordResetTokenLink
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            client.Connect(host, port, enableSSL);
            client.Authenticate(mail, password);
            client.Send(mimeMessage);
            client.Disconnect(true);
            ViewBag.Message = "Mail başarıyla gönderildi.";
            return View();
        }
        public IActionResult ResetPassword(string userId, string token)
        {
            var model = new ResetPasswordDto
            {
                UserId = userId,
                Token = token
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı bulunamadı");
                return View(dto);
            }
            var result = await _userManager.ResetPasswordAsync(user, dto.Token, dto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View(dto);
        }
    }
}
