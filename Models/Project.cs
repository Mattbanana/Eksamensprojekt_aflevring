using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_2nd.Models
{
    public class Project
    {
        public string? project_name { get; set; }
        public string? project_number { get; set; }
        public double hours_planed { get; set; }
        public DateOnly start_date { get; set; }
        public DateOnly end_date { get; set; }
        public string? comment { get; set; }


        //constructor
        public Project() { }


    }
}
