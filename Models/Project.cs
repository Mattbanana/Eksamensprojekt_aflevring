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
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string? comment { get; set; }


        //constructor
        public Project( string project_name, string project_number, double hours_planed,
             string start_date, string end_date, string comment)
        {
            this.project_name = project_name;
            this.project_number = project_number;
            this.hours_planed = hours_planed;
            this.start_date = start_date;
            this.end_date = end_date;
            this.comment = comment;
        
        
        }


    }
}
