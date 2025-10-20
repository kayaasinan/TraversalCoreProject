using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DTOLayer.DTOs.MailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        private readonly IMailDal _mailDal;

        public MailManager(IMailDal mailDal)
        {
            _mailDal = mailDal;
        }

        public void TSendMail(MailRequestDTO mailRequest)
        {
            _mailDal.SendMail(mailRequest);
        }
    }
}
