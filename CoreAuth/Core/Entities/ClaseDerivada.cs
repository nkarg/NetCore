using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ClaseDerivada: ClaseMaestra
    {
        public string Type { get; set; }

        public new string Metodo()
        {
            return "Metodo Estatico desde Clase DERIVADA";
        }

        public override string MetodoVirtual()
        {
            return "Metodo Virtual desde Clase DERIVADA";
        }

        public string MetodoBase()
        {
            return base.Metodo();
        }

        public string MetodoVirtualBase()
        {
            return base.MetodoVirtual();
        }
    }
}
