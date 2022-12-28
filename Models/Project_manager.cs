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
        public string? Employee_ref { get; set; }
        public string? Phone_number { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public int? Hours_available_per_month { get; set; }


        // Constructor
        public Project_manager(string _Name, string _Employee_ref, string _Phone_number, string _Email, 
            string _Comment, int _Hours_available_per_month) 
        { 
            this.Name = _Name;
            this.Employee_ref = _Employee_ref;
            this.Phone_number = _Phone_number;
            this.Email = _Email;
            this.Comment = _Comment;
            this.Hours_available_per_month = _Hours_available_per_month;

        }
    }
}
