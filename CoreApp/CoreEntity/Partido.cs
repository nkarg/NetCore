using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEntity
{
    public class Partido
    {
        public Equipo EquipoLocal { get; set; }
        public int GolesLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public int GolesVisitante { get; set; }

        public string Resultado() {
            var str = string.Empty;
            if (GolesLocal > GolesVisitante)
            {
                str = $"Ganó el equipo local {EquipoLocal.Nombre} por {GolesLocal} a {GolesVisitante}";
            }
            else if(GolesLocal < GolesVisitante)
            {
                str = $"Ganó el equipo visitante {EquipoVisitante.Nombre} por {GolesVisitante} a {GolesLocal}";
            }
            else
            {
                str = "Empate entre ambos equipos";
            }

            return str;
        }
    }
}
