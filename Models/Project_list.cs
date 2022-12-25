using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eksamensprojekt_2nd.Models
{
    class Project_list
    {
        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
        
       public List<Project> Create()
        {

            List<Project> Project_list = new List<Project>();

            return Project_list;
        }


        public void Load()
        {
            List<Project>  Projects = new List<Project>();
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Projects_table_5", connection);
                using (var reader = command.ExecuteReader())
                {
                    //while (reader.Read())
                    //{
                    //    var project = new Project();
                    //    project.PK_project = reader.GetInt32(0);
                    //    project.Project_name = reader.GetString(1);
                    //    project.Project_number = reader.GetString(2);
                    //    project.Hours_planed = reader.GetDouble(3);
                    //    project.Start_date = reader.GetString(4);
                    //    project.End_date = reader.GetString(5);
                    //    project.Comment = reader.GetString(6);
                    //    Loaded_Project_list.Add(project);
                    //}


                    while (reader.Read())
                    {
                        
                        if (Projects.Count > 0)
                        {
                            Projects.Clear();
                        }
                        
                        Project project = new Project(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetInt32(3),
                        reader.GetString(4),
                        reader.GetString(5),
                        reader.GetString(6));
                        Projects.Add(project);
                    }
                }
            }
        }
    }

}

