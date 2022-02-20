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
        public Email(EmailInput dto)
        {
            Create(dto);
        }

        private void Create(EmailInput dto)
        {

            email = dto.email;
            EmailType = dto.EmailType;
            CreateEntity();
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
