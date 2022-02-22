using Domain.DTOs.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : Entity
    {

        public Address() { }
        public Address(int studentId, Student student, AddressInput dto)
        {
            Create(studentId, student, dto);
        }

        private void Create(int studentId, Student student, AddressInput dto)
        {
            AddressLine = dto.AddressLine;
            City = dto.City;
            ZipPostCode = dto.ZipPostCode;
            State = dto.State;
            StudentId = studentId;

            CreateEntity();
            student.Addresses.Add(this);
        }

        public void Edit(AddressInput dto)
        {
            AddressLine = dto.AddressLine;
            City = dto.City;
            ZipPostCode = dto.ZipPostCode;
            State = dto.State;


            EditEntity();
        }


        public AddressOutput ToOutput()
        {
            return new AddressOutput
            {
                Id = Id,
                AddressLine = AddressLine,
                City = City,
                ZipPostCode = ZipPostCode,
                State = State
            };
        }

        public string AddressLine { get; private set; }
        public string City { get; private set; }
        public string ZipPostCode { get; private set; }
        public string State { get; private set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
