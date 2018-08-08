using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tabla.Models
{
    public class JugadorViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        [Display(Name = "Es Titular")]
        public bool EsTitular { get; set; }

        [Required]
        [Display(Name = "Equipo")]
        public string Equipo { get; set; }

        [Required]
        [Display(Name = "Posición")]
        public string Posicion { get; set; }

        public int Edad { get; set; }
    }
}
