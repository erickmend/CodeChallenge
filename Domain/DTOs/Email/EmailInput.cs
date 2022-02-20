using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Email
{
    public class EmailInput
    {
        public string email { get;   set; }
        public EmailType EmailType { get;   set; }
    }
}
