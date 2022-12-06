using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_2nd.Models
{
    public class Project
    {
        public string? Project_name { get; set; }
        public string? Project_number { get; set; }
        public double Hours_planed { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string? Comment { get; set; }


        //constructor
        public Project( string project_name, string project_number, double hours_planed,
             string start_date, string end_date, string comment)
        {
            this.Project_name = project_name;
            this.Project_number = project_number;
            this.Hours_planed = hours_planed;
            this.Start_date = start_date;
            this.End_date = end_date;
            this.Comment = comment;
        
        
        }


    }
}
