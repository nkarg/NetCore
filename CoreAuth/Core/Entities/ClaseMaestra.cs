using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class ClaseMaestra : IMaestra
    {
        public string Key { get; set; }

        public string Metodo()
        {
            return "Metodo Estatico desde Clase MAESTRA";
        }

        public virtual string MetodoVirtual()
        {
            return "Metodo Virtual desde Clase MAESTRA";
        }
    }
}
