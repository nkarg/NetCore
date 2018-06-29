using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CoreEntity
{
    public class Formateador : IFormateador
    {
        public string NombreCompleto(IEquipo equipo)
        {
            return $"Inyectado: {equipo.Nombre} {Guid.NewGuid().ToString()} ID OBJ {this.GetHashCode()}";
        }
    }
}
