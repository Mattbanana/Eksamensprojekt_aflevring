using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_2nd.Models
{
    class Project_manager
    {
        public string? Name { get; set; }
        public string? Employee_number { get; set; }
        public string? Phone_number { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public double? Hours_available_per_month { get; set; }


        // Constructor
        public Project_manager() 
        { 
        }
    }
}
