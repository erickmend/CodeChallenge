using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Phone
{
    public class PhoneInput
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Teléfono")]
        public string phone { get;   set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipo")]
        public PhoneType PhoneType { get;   set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Codigo de país")]
        public string CountryCode { get;   set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Código de area")]
        public string AreaCode { get;   set; }
    }
}
