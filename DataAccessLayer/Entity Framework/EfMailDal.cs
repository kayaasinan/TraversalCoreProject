using DataAccessLayer.Abstract;
using DTOLayer.DTOs;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MimeKit;

namespace DataAccessLayer.Entity_Framework
{
    public class EfMailDal : IMailDal
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public EfMailDal(IConfiguration configuration, ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public void SendMail(MailRequestDTO mailRequest)
        {
            var mailSettings = _configuration.GetSection("MailSettings");

            if (string.IsNullOrEmpty(mailSettings["Mail"]) || string.IsNullOrEmpty(mailSettings["Password"]))
                _logger.LogWarning("MailSettings eksik veya hatalı yapılandırılmış!");

            string mail = mailSettings["Mail"]!;
            string displayName = mailSettings["DisplayName"]!;
            string password = mailSettings["Password"]!;
            string host = mailSettings["Host"]!;
            int port = int.Parse(mailSettings["Port"]!);
            bool enableSSL = bool.Parse(mailSettings["EnableSSL"]!);

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress(displayName, mail));
            mimeMessage.To.Add(new MailboxAddress("User", mailRequest.ReceiverMail));
            mimeMessage.Subject = mailRequest.Subject;

            var bodyBuilder = new BodyBuilder
            {
                TextBody = mailRequest.Body
            };

            mimeMessage.Body = bodyBuilder.ToMessageBody();

            using var client = new SmtpClient();
            client.Connect(host, port, enableSSL);
            client.Authenticate(mail, password);
            client.Send(mimeMessage);
            client.Disconnect(true);
        }
    }
}
