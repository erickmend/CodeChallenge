using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Address
{
    public class AddressInput
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Dirección")]
        public string AddressLine { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Ciudad")]
        public string City { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Código postal")]
        public string ZipPostCode { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public string State { get; set; }
    }
}
