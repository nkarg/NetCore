using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Jugador
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool EsTitular { get; set; }
        public string Equipo { get; set; }
        public string Posicion { get; set; }

        public int Edad()
        {
            return (FechaNacimiento != null ? -1 : DateTime.Today.Year - FechaNacimiento.Year);
        }
    }
}
