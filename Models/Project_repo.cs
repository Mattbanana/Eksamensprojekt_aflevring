using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Eksamensprojekt_2nd.Views;

namespace Eksamensprojekt_2nd.Models
{
    class Project_repo
    {
        //model class for a project repossitory that reads the rows in the database and adds them to a list
        public static List<Project> GetAllProjectTableDB()
        {
            //This method is used to retrive all projects in the database to a list
            //it does so by using System.Data.SqlClient to connect, execute query and close the connection.
            //a while loop is used to iterate over selected columns, reading all the rows in the database and adds the rows as Project objects
            //that gets added to the Projects_repo list
            //the using statement is used to make sure the connection is closed after the query is executed.
            //its all wraped in a try-catch statement, if it fails it will throw an exception that makes a massage box appear with the error message.
            List<Project> Projects_repo = new();
            string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM Project_table";
                   
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                            {

                                Project project = new Project(
                                    reader.GetString(2),
                                    reader.GetString(3),
                                    reader.GetInt32(4),
                                    reader.GetDateTime(5),
                                    reader.GetDateTime(6),
                                    reader.GetString(7));
 
                                Projects_repo.Add(project);
                            } 
                        
                    }
                }              
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return Projects_repo;
        }
  

    }
}

