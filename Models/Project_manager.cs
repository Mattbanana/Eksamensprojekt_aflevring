using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_2nd.Models
{
    class project_manager
    {
        public string? name { get; set; }
        public string? employee_number { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? comment { get; set; }
        public double? hours_available_per_month { get; set; }


        // Constructor
        public project_manager() 
        { 
        }
    }
}
