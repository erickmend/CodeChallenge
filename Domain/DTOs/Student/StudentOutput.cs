using Domain.DTOs.Address;
using Domain.DTOs.Email;
using Domain.DTOs.Phone;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Student
{
    public class StudentOutput
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Máximo es de 45 carateres")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Máximo es de 45 carateres")]
        [Display(Name = "MiddleName")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Máximo es de 45 carateres")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Género")]
        public Gender Gender { get; set; }

        public List<EmailOutput> Emails { get; set; }
        public List<AddressOutput> Addresses { get; set; }
        public List<PhoneOutput> Phones { get; set; }


        public string GetFullName()
        {
            return FirstName + " "+ LastName +" "+ MiddleName;
        }
    }
}
