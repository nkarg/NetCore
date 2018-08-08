using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAuth.Areas.Admin.Models
{
    public class ManagementViewModel
    {
        public int Id { get; set; }
        public bool AllowConfig { get; set; }
        public string ConnectionString { get; set; }
    }
}
