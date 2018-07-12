using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IMaestra
    {
        string Key { get; set; }

        string Metodo();
        string MetodoVirtual();
    }
}
