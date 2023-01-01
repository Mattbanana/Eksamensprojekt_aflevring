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
        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

        public int? PK_Project { get; set; }
        public int FK_Project_manager { get; set; }
        public string Project_name { get; set; }
        public string Project_ref { get; set; }
        public int Hours_planed { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public string Comment { get; set; }


        //constructor
        public Project( string _Project_name, string _Project_ref, int _Hours_planed,
             DateTime _Start_date, DateTime _End_date, string _Comment)
        {
            this.Project_name = _Project_name;
            this.Project_ref = _Project_ref;
            this.Hours_planed = _Hours_planed;
            this.Start_date = _Start_date;
            this.End_date = _End_date;
            this.Comment = _Comment;
        }
        public void CreateProjectInDBtable()
        {
            //This method is used to create a new project in the database
            //it does so by using System.Data.SqlClient to connect, execute query and close the connection. The query adds a new project to the database,
            //follow by a confirmation message.
            //its all wraped in a try-catch statement, if it fails it will throw an exception that makes a massage box appear with the error message.
            try
            {
                 using (SqlConnection connection = new SqlConnection(connectionString))
                 {
                    connection.Open();

                    string sql = "INSERT INTO Project_table (Name,Project_ref,Hours_planed,Start_date,End_date,Comment) " +
                        "VALUES (@Project_name,@Project_ref, @Hours_planed, @Start_date, @End_date, @Comment)";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Project_name", this.Project_name);
                    command.Parameters.AddWithValue("@Project_ref", this.Project_ref);
                    command.Parameters.AddWithValue("@hours_planed", this.Hours_planed);
                    command.Parameters.AddWithValue("@Start_date", this.Start_date);
                    command.Parameters.AddWithValue("@End_date", this.End_date);
                    command.Parameters.AddWithValue("@Comment", this.Comment);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Project created");
                }
            }
            catch(SqlException ex) 
            {
                
                MessageBox.Show(ex.Message);
        
            }
        }
        
    }
}
