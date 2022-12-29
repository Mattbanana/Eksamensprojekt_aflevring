using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Eksamensprojekt_2nd.Models
{
    class Project_manager
    {
        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
        public int? PK_Project_manager { get; set; }
        public string Name { get; set; }
        public string? Employee_ref { get; set; }
        public string? Phone_number { get; set; }
        public string? Email { get; set; }
        public string? Comment { get; set; }
        public int? Hours_available_per_month { get; set; }
        
        


        // Constructor
        public Project_manager(string _Name, string _Employee_ref, string _Phone_number, string _Email, 
            string _Comment, int _Hours_available_per_month) 
        { 
            this.Name = _Name;
            this.Employee_ref = _Employee_ref;
            this.Phone_number = _Phone_number;
            this.Email = _Email;
            this.Comment = _Comment;
            this.Hours_available_per_month = _Hours_available_per_month;

        }


        //Adds a new project manager to the database with input values from the user
        public void CreateProjectManagerInDBTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "INSERT INTO Project_Manager_table (Name,Employee_ref,Phone_number,Email,Hours_available_per_month,Comment) " +
                        "VALUES (@Name,@Employee_ref, @Phone_number, @Email, @Hours_available_per_month,@Comment)";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Name", this.Name);
                    command.Parameters.AddWithValue("@Employee_ref", this.Employee_ref);
                    command.Parameters.AddWithValue("@Phone_number", this.Phone_number);
                    command.Parameters.AddWithValue("@Email", this.Email);
                    command.Parameters.AddWithValue("@Hours_available_per_month", this.Hours_available_per_month);
                    command.Parameters.AddWithValue("@Comment", this.Comment);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Project Manager created");
                }
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);

            }
        }
        


        public void CreateProjectManagerTableInDB()
        {
                
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();

                    string sql = "CREATE TABLE Project_Manager_table(" +
                    "PK_project int PRIMARY KEY IDENTITY," +
                    "Name nvarchar(100)," +
                    "Employee_ref nvarchar(100)," +
                    "Phone_number nvarchar(50)," +
                    "Email nvarchar(100)," +
                    "Hours_available_per_month int," +
                    "Comment nvarchar(1000))";

                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();

                    MessageBox.Show("Project Manager table created");

                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.Message);

                }

            }


        }


    }

    




}




