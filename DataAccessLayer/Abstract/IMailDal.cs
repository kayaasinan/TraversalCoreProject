using DTOLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMailDal
    {
        void SendMail(MailRequestDTO mailRequest);
    }
}
