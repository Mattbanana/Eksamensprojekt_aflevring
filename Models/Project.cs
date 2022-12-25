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
        //public int? PK_project { get; set; }
        public string Project_name { get; set; }
        public string Project_number { get; set; }
        public int Hours_planed { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Comment { get; set; }

        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

        //constructor
        public Project( string project_name, string project_number, int hours_planed,
             DateTime start_date, DateTime end_date, string comment)
        {
           // this.PK_project = pk_projects;
            this.Project_name = project_name;
            this.Project_number = project_number;
            this.Hours_planed = hours_planed;
            this.Start_date = start_date;
            this.End_date = end_date;
            this.Comment = comment;
        }
        
        public void GreateProjectInProjectTable()
        {
            try
            {
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                    connection.Open();

                    string sql = "INSERT INTO Project_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
                        "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Project_name", this.Project_name);
                    command.Parameters.AddWithValue("@Project_ID", this.Project_number);
                    command.Parameters.AddWithValue("@hours_planed", this.Hours_planed);
                    command.Parameters.AddWithValue("@Start_date", this.Start_date);
                    command.Parameters.AddWithValue("@End_date", this.End_date);
                    command.Parameters.AddWithValue("@Comment", this.Comment);

                    command.ExecuteNonQuery();
                }
            }
            catch(SqlException ex) 
            {
                MessageBox.Show(""+ex, "");
        
            }
        }


        //public List<Project> ReadProjectTable()
        //{
            
            
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = "SELECT * FROM project_table_5";
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        SqlDataReader reader = command.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            if (projectList.Count > 0)
        //            {
        //                projectList.Clear();
        //            }
        //            Project project = new Project(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetDouble(3), reader.GetString(4), reader.GetString(5), reader.GetString(6));
        //            projectList.Add(project);
        //        }
        //    }
        //    return projectList;
        //}



        ////a methodd that creates a table in a ms sql database.
        //public void CreateTable()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = "CREATE TABLE Project_table (" +
        //            "PK_projects int PRIMARY KEY IDENTITY," +
        //            "Name varchar(100)," +
        //            "Hours_planed int," +
        //            "Project_ID varchar(100)," +
        //            "Start_date datetime," +
        //            "End_date datetime," +
        //            "Comment varchar(1000))";
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}


        //public void CreateTestTable()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        connection.Open();
        //        string sql = "CREATE TABLE Test_table(" +
        //            // "PK_projects int PRIMARY KEY IDENTITY," +
        //            "PK_projects nvarchar(10)" +
        //            "Name nvarchar(10)," +
        //            "Hours_planed nvarchar(10)," +
        //            "Project_ID nvarchar(10)," +
        //            "Start_date nvarchar(10)," +
        //            "End_date nvarchar(10)," +
        //            "Comment nvarchar(10)";
        //        SqlCommand command = new SqlCommand(sql, connection);
        //        command.ExecuteNonQuery();
        //    }
        //}


        //A class to test data connection to database, for debuging purposes.

        //public void Testdataaccess()
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {

        //    int? Test_1 = 0;
        //    string Test_2 = "en lakssdsd";

        //    connection.Open();
        //    string sql = "INSERT INTO Project_table_4 (Name,Project_ID) VALUES (@Project_name,@Project_ID )";

        //    SqlCommand command = new SqlCommand(sql, connection);

        //    //command.Parameters.AddWithValue("@PK_project", Test_1);
        //    command.Parameters.AddWithValue("@Project_name", Test_2);
        //    command.Parameters.AddWithValue("@Project_ID", Test_1);
        //    //command.Parameters.AddWithValue("@Hours_planed", Hours_planed);
        //    //command.Parameters.AddWithValue("@Start_date", Start_date);
        //    //command.Parameters.AddWithValue("@End_date", End_date);
        //    //command.Parameters.AddWithValue("@Comment", Comment);
        //    command.ExecuteNonQuery();
        //    }




        //}
    }
}
