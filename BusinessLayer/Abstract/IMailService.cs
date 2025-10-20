using DTOLayer.DTOs.MailDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMailService
    {
        void TSendMail(MailRequestDTO mailRequest);
    }
}
