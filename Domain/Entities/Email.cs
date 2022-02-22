using Domain.DTOs.Email;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Email : Entity
    {


        public Email() { }
        public Email(int studentId, Student student, EmailInput dto)
        {
            Create(studentId, student, dto);
        }

        private void Create(int studentId, Student student, EmailInput dto)
        {

            email = dto.email;
            EmailType = dto.EmailType;
            StudentId = studentId;

            CreateEntity();
            student.Emails.Add(this);
        }

        public void Edit(EmailInput dto)
        {
            email = dto.email;
            EmailType = dto.EmailType;


            EditEntity();
        }


        public EmailOutput ToOutput()
        {
            return new EmailOutput
            {
                Id = Id,
                email = email,
                EmailType = EmailType
            };
        }

        public string email { get; private set; }
        public EmailType EmailType { get; private set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
