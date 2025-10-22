using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AccountDTOs
{
    public class AccountDto
    {
        public int? AccountId { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public decimal Amount { get; set; }
  
    }
}
