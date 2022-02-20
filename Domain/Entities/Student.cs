using Domain.DTOs.Student;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Student : Entity
    {
        public Student() { }
        public Student(StudentInput dto)
        {

        }

        private void Create(StudentInput dto)
        {
            LastName = dto.LastName;
            MiddleName = dto.MiddleName;
            FirstName = dto.FirstName;
            Gender = dto.Gender;

            Emails = new List<Email>();
            Addresses = new List<Address>();
            Phones = new List<Phone>();

            CreateEntity();
        }

        public void Edit(StudentInput dto)
        {
            LastName = dto.LastName;
            MiddleName = dto.MiddleName;
            FirstName = dto.FirstName;
            Gender = dto.Gender;

            EditEntity();
        }

        public StudentOutput ToOutput()
        {
            return new StudentOutput
            {
                Id = Id,
                LastName = LastName,
                MiddleName = MiddleName,
                FirstName = FirstName,
                Gender = Gender,
                Emails = Emails.Select(x => x.ToOutput()).ToList(),
                Addresses = Addresses.Select(x => x.ToOutput()).ToList(),
                Phones = Phones.Select(X => X.ToOutput()).ToList()
            };
        }

        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public string FirstName { get; private set; }
        public Gender Gender { get; private set; }

        public List<Email> Emails { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Phone> Phones { get; set; }
    }
}
