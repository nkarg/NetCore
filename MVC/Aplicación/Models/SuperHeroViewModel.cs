﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicación.Models
{
    public class SuperHeroViewModel
    {
        [Required]
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Hability { get; set; }
        public bool IsActive { get; set; }
    }
}
