using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.ContactUsDTOs
{
    public class ContactUsDto
    {
        public int ContactUsId { get; set; }
        public string? Name { get; set; }
        public string? Mail { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}
