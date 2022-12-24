using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Eksamensprojekt_2nd.Views;
using System.Windows;

namespace Eksamensprojekt_2nd.Models
{
    public class Project
    {
        public int? PK_project { get; set; }
        public string? Project_name { get; set; }
        public string? Project_number { get; set; }
        public double? Hours_planed { get; set; }
        public string? Start_date { get; set; }
        public string? End_date { get; set; }
        public string? Comment { get; set; }


        //constructor
        public Project( int pk_projects, string project_name, string? project_number, double hours_planed,
             string start_date, string end_date, string comment)
        {
            this.PK_project = pk_projects;
            this.Project_name = project_name;
            this.Project_number = project_number;
            this.Hours_planed = hours_planed;
            this.Start_date = start_date;
            this.End_date = end_date;
            this.Comment = comment;

            //intitialize project with default values

            //this.Project_name = "to laks";
            //this.Project_number = "140";
            //this.Hours_planed = 134;
            //this.Start_date = "20-11-2026";
            //this.End_date = "20-11-2027";
            //this.Comment = "stor";


        }
        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

        //a method that saves the Project class to a table named project_table in a ms sql database.
        //with fields corresponding to the properties of the Project class.
        
        
        public void GreateProject()
        {
            try
            {
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                    connection.Open();
                    int? Test_int = 343;
                    string Test_string_1 = "en lakssdsdsd";


                    string sql = "INSERT INTO Project_table_4 (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";

                    SqlCommand command = new SqlCommand(sql, connection);

                    //command.Parameters.AddWithValue("@PK_project", Test_1);
                    command.Parameters.AddWithValue("@Project_name", this.Project_name);
                    command.Parameters.AddWithValue("@Project_ID", this.Project_number);
                    command.Parameters.AddWithValue("@hours_planed", this.Hours_planed);
                    command.Parameters.AddWithValue("@Start_date", this.Start_date);
                    command.Parameters.AddWithValue("@End_date", this.End_date);
                    command.Parameters.AddWithValue("@Comment", this.Comment);

                    //"PK_projects int," +
                    //"Name varchar(100)," +
                    //"Hours_planed int," +
                    //"Project_ID varchar(100)," +
                    //"Start_date date," +
                    //"End_date date," +
                    //"Comment varchar(1000))";



                    //string sql = "INSERT INTO Projects_table_4 (PK_projects, Name, Hours_planed," +
                    //        " Project_ID, Start_date, End_date, Comment) " +
                    //        "VALUES (@PK_projects, Project_name, @Project_ID, @Hours_planed, " +
                    //        "@Project_ID, @Start_date, @End_date, @Comment)";

                    //        SqlCommand command = new SqlCommand(sql, connection);

                    //        command.Parameters.AddWithValue("@PK_projects", this.PK_project);
                    //        command.Parameters.AddWithValue("@Project_name", Test_string_1);
                    //        command.Parameters.AddWithValue("@Hours_planed", Test_int);
                    //        command.Parameters.AddWithValue("@Project_ID", this.Hours_planed);
                    //        command.Parameters.AddWithValue("@Start_date", this.Start_date);
                    //        command.Parameters.AddWithValue("@End_date", this.End_date);
                    //        command.Parameters.AddWithValue("@Comment", this.Comment);
                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException ex) 
            {
                MessageBox.Show("Some text" + ex, "Some title");
        
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



        //a methodd that creates a table in a ms sql database.
        //the table is named project_table and has fields corresponding to the properties of the Project class.
        public void CreateTable()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE project_table_4 (" +
                    "PK_projects int," +
                    "Name varchar(100)," +
                    "Hours_planed int," +
                    "Project_ID varchar(100)," +
                    "Start_date date," +
                    "End_date date," +
                    "Comment varchar(1000))";
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
        }




        public void Testdataaccess()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

            int? Test_1 = 0;
            string Test_2 = "en lakssdsd";

            connection.Open();
            string sql = "INSERT INTO Project_table_4 (Name,Project_ID) VALUES (@Project_name,@Project_ID )";

            SqlCommand command = new SqlCommand(sql, connection);

            //command.Parameters.AddWithValue("@PK_project", Test_1);
            command.Parameters.AddWithValue("@Project_name", Test_2);
            command.Parameters.AddWithValue("@Project_ID", Test_1);
            //command.Parameters.AddWithValue("@Hours_planed", Hours_planed);
            //command.Parameters.AddWithValue("@Start_date", Start_date);
            //command.Parameters.AddWithValue("@End_date", End_date);
            //command.Parameters.AddWithValue("@Comment", Comment);
            command.ExecuteNonQuery();
            }




        }
    }
}
