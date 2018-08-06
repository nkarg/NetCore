using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class SuperHeroEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hability { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"Mi nombre es: {Name}, Mi habilidad: {Hability} y estoy {IsActive.ToString()}";
        }
    }
}
