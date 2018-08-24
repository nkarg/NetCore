using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class EquipoEntity
    {
        public int EquipoId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public EquipoInfoEntity EquipoInfo { get; set; }
    }
}
