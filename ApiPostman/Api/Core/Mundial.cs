using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Core
{
    public static class Mundial
    {
        public static List<Equipo> Equipos()
        {
            var lista = new List<Equipo> { new Equipo { Nombre = "Argentina" },
                                           new Equipo { Nombre = "Brasil" },
                                           new Equipo { Nombre = "Croacia" },
                                           new Equipo { Nombre = "Alemania" }
                                          };

            return lista;
        }
    }
}
