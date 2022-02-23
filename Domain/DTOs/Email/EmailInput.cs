using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Email
{
    public class EmailInput
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Correo")]
        public string email { get;   set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo")]
        public EmailType EmailType { get;   set; }
    }
}
