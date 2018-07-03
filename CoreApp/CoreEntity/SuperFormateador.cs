using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEntity
{
    public class SuperFormateador : IFormateador
    {
        public string NombreCompleto(IEquipo equipo)
        {
            return $"{equipo.Nombre} Formateado recapo !!";
        }
    }
}
