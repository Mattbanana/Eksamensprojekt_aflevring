using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

        //a method that saves the properties of project to a database
        public void Save()
        {
            //connection string
            string connectionString = "Server=10.56.8.37 ;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
            //sql query
            string sql = "INSERT INTO Project (Project_name, Project_number, Hours_planed, Start_date, End_date, Comment) " +
                         "VALUES (@Project_name, @Project_number, @Hours_planed, @Start_date, @End_date, @Comment)";
            //connection
            SqlConnection connection = new SqlConnection(connectionString);

            //command
            SqlCommand command = new SqlCommand(sql, connection);
            //parameters
            command.Parameters.AddWithValue("@Project_name", Project_name);
            command.Parameters.AddWithValue("@Project_number", Project_number);
            command.Parameters.AddWithValue("@Hours_planed", Hours_planed);
            command.Parameters.AddWithValue("@Start_date", Start_date);
            command.Parameters.AddWithValue("@End_date", End_date);
            command.Parameters.AddWithValue("@Comment", Comment);
            //open connection
            connection.Open();
            //execute command
            command.ExecuteNonQuery();
            //close connection
            connection.Close();
        }



    }
}
