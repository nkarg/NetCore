using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEntity
{
    public class Formateador : IFormateador
    {
        public string NombreCompleto(IEquipo equipo)
        {
            return $"Inyectado: {equipo.Nombre}";
        }
    }
}
