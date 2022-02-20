using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Phone
{
    public class PhoneOutput
    {
        public int Id { get; set; }
        public string phone { get; set; }
        public PhoneType PhoneType { get; set; }
        public string CountryCode { get; set; }
        public string AreaCode { get; set; }
    }
}
