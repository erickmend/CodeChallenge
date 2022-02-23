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
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El Máximo es de 100 carateres")]
        [DataType(DataType.EmailAddress , ErrorMessage ="Ingresa un correo válido")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Ingresa un correo válido")]
        [Display(Name = "Correo")]
        public string email { get;   set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo")]
        public EmailType EmailType { get;   set; }
    }
}
