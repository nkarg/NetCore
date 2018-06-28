using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEntity
{
    public class Equipo: IEquipo
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
    }
}
