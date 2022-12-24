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
        public int PK_projects { get; set; }
        public string? Project_name { get; set; }
        public string? Project_number { get; set; }
        public double Hours_planed { get; set; }
        public string Start_date { get; set; }
        public string End_date { get; set; }
        public string? Comment { get; set; }


        //constructor
        public Project( int pk_projects, string project_name, string project_number, double hours_planed,
             string start_date, string end_date, string comment)
        {
            this.PK_projects = pk_projects;
            this.Project_name = project_name;
            this.Project_number = project_number;
            this.Hours_planed = hours_planed;
            this.Start_date = start_date;
            this.End_date = end_date;
            this.Comment = comment;
        
        
        }
        string connectionString = "Server=10.56.8.37 ;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
        
        //a method that saves the Project class to a table named project_table in a ms sql database.
        //with fields corresponding to the properties of the Project class.
         
        public void SaveProject()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "INSERT INTO project_table (PK_ID, Project_name, Project_number, Hours_planed, Start_date, End_date, Comment) VALUES (@PK_ID, @Project_name, @Project_number, @Hours_planed, @Start_date, @End_date, @Comment)";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@PK_projects", PK_projects);
                command.Parameters.AddWithValue("@Name", Project_name);
                command.Parameters.AddWithValue("@Hours_planed", Project_number);
                command.Parameters.AddWithValue("@Project_ID", Hours_planed);
                command.Parameters.AddWithValue("@Start_date", Start_date);
                command.Parameters.AddWithValue("@End_date", End_date);
                command.Parameters.AddWithValue("@Comment", Comment);
                command.ExecuteNonQuery();
            }
        }

        //a method that Reads that reads all the entries table project table in a ms sql database.
        //and returns a list of Project objects.
        // if the list already contains entries, the method clears the list before adding new entries.

        public List<Project> ReadProject()
        {
            List<Project> projectList = new List<Project>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "SELECT * FROM project_table";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (projectList.Count > 0)
                    {
                        projectList.Clear();
                    }
                    Project project = new Project(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
                    projectList.Add(project);
                }
            }
            return projectList;
        }

       




    }
}
