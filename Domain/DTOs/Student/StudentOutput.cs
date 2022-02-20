using Domain.DTOs.Address;
using Domain.DTOs.Email;
using Domain.DTOs.Phone;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Student
{
    public class StudentOutput
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FirstName { get; set; }
        public Gender Gender { get; set; }

        public List<EmailOutput> Emails { get; set; }
        public List<AddressOutput> Addresses { get; set; }
        public List<PhoneOutput> Phones { get; set; }
    }
}
