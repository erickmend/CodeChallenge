using Domain.DTOs.Phone;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Phone : Entity
    {
        public Phone() { }
        public Phone(int studentId, Student student, PhoneInput dto)
        {
            Create(studentId, student, dto);
        }
        private void Create(int studentId, Student student, PhoneInput dto)
        {
            phone = dto.phone;
            PhoneType = dto.PhoneType;
            CountryCode = dto.CountryCode;
            AreaCode = dto.AreaCode;
            StudentId = studentId;
            CreateEntity();


            student.Phones.Add(this);
        }

        public void Edit(PhoneInput dto)
        {
            phone = dto.phone;
            PhoneType = dto.PhoneType;
            CountryCode = dto.CountryCode;
            AreaCode = dto.AreaCode;

            EditEntity();
        }

        public PhoneOutput ToOutput()
        {
            return new PhoneOutput
            {
                Id = Id,
                phone = phone,
                PhoneType = PhoneType,
                CountryCode = CountryCode,
                AreaCode = AreaCode
            };
        }

        public string phone { get; private set; }
        public PhoneType PhoneType { get; private set; }
        public string CountryCode { get; private set; }
        public string AreaCode { get; private set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
