using System;
using System.Collections.Generic;
using System.Text;

namespace CoreEntity
{
    public class PartidoErrorException : Exception
    {
        public string Equipo1 { get; set; }
        public string Equipo2 { get; set; }

        public PartidoErrorException():base("Esto no puede continuar")
        {
             
        }

        public override string ToString()
        {
            return $"Error entre {Equipo1} vs {Equipo2}, Error: {Message}";
        }
    }
}
