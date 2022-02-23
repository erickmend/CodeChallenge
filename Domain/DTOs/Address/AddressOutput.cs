using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Address
{
    public class AddressOutput
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El Máximo es de 100 carateres")]
        [Display(Name = "Dirección")]
        public string AddressLine { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Máximo es de 45 carateres")]
        [Display(Name = "Ciudad")]
        public string City { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(0, double.MaxValue, ErrorMessage = "Ingresa solo números")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Máximo es de 45 carateres")]
        [Display(Name = "Código postal")]
        public string ZipPostCode { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(45, MinimumLength = 1, ErrorMessage = "El Máximo es de 45 carateres")]
        [Display(Name = "Estado")]
        public string State { get; set; }
    }
}
