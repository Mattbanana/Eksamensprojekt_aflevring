﻿using System;
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
        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
   
        
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

        void CreateProjectTableInDB()

        {
            //string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE Project_table(" +
                    "PK_projects int PRIMARY KEY IDENTITY," +
                    "FK_project_manager int," +
                    "Name nvarchar(100)," +
                    "Project_ID nvarchar(100)," +
                    "Hours_planed int," +
                    "Start_date DateTime," +
                    "End_date DateTime," +
                    "Comment nvarchar(1000))";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }
        }



        //metoder som bliver brugt til at oprette table i database
        //samt query 10 rækker af genereret data til DB
        public List<Project> Generate_ProjectList_with_Data()

        {
            List<Project> projects_list = new List<Project>();

            //a foreach-loop that genrates a list of Test_Project(nvarchar(100) "Project_2", int "20" (random between 100 and 150), nvarchar(100) (random funny text), dateonly "01-01-2020" (near future dates), dateonly "01-01-2020"(far future date), nvarchar(100) "Comment_2"(some fun comment)) with test data

            foreach (int i in Enumerable.Range(1, 10))
            {

                    projects_list.Add(new Project("Project_" + i, "Project_ID_" + i, new Random().Next(100, 150),
                    GetRandomNearFutureDate(), GetRandomFarFutureDate(), "Comment_" + i));
            }
            
            return projects_list;

            static DateTime GetRandomNearFutureDate()
            {
                var today = DateTime.Today;
                return today.AddDays(new Random().Next(1, 30));
            }

            // Method to generate a random date in the far future
            static DateTime GetRandomFarFutureDate()
            {
                var today = DateTime.Today;
                return today.AddDays(new Random().Next(365, 730));
            }
        }

        void WritelistToDB(List<Project> projects_list)
        {
            using (SqlConnection connection = new SqlConnection("Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;"))
            {
                connection.Open();

                //string sql = "INSERT INTO Test_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
 
                    //   "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";
                    
                foreach (Project project in projects_list)
                {
                    string sql = "INSERT INTO Test_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
                    "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";
                    
                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Project_name", project.Project_name);
                    command.Parameters.AddWithValue("@Project_ID", project.Project_ref);
                    command.Parameters.AddWithValue("@Hours_planed", project.Hours_planed);
                    command.Parameters.AddWithValue("@Start_date", project.Start_date);
                    command.Parameters.AddWithValue("@End_date", project.End_date);
                    command.Parameters.AddWithValue("@Comment",project.Comment);
                    
                    command.ExecuteNonQuery();
                }

            }

        }

       

    }
}

