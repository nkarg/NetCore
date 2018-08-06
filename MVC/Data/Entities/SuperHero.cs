using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Entities
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Hability { get; set; }
        public bool IsActive { get; set; }
    }
}
