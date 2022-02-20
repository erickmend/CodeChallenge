using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Address
{
    public class AddressInput
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string ZipPostCode { get; set; }
        public string State { get; set; }
    }
}
