using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyVet.Web.Data.Entities
{
    public class Owner
    {
        [Key]
        public int IdOwner { get; set; }

        [Required]
        [MaxLength(30)]
        public string Document { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Nombres")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
        
        [MaxLength(20)]
        [Display(Name = "Linea Baja")]
        public string FixedPhone { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Celular")]
        public string CellPhone { get; set; }

        [MaxLength(100)]
        [Display(Name = "Domicilio")]
        public string Address { get; set; }
        [Display(Name = "Propietario")]
        public string FullName => $"{FirstName}{LastName}";

        [Display(Name = "Propietario")]
        public string FullNameWithDocument => $"{FirstName}{LastName} - {Document} ";

    }
}
