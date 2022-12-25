using Eksamensprojekt_2nd.Models;
using Eksamensprojekt_2nd.Viewmodels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace Eksamensprojekt_2nd.Views
{
    /// <summary>
    /// Interaction logic for Projects_view.xaml
    /// </summary>
    public partial class Projects_view : UserControl
    {
        public Projects_view()
        {
            InitializeComponent();

            //List<Test_Project> Test_projects_list_W_Testdata = GenerateTestDataList();

            //CreateTestTable();

            //WriteTestToTestDB(Test_projects_list_W_Testdata);





           // List<Test_Project> Test_projects_list = new List<Test_Project>();

            List<Test_Project> Test_projects_list = LoadProjectsFromTesttable();
            
            projects_listview.ItemsSource = Test_projects_list;
            
            

        }

            private List<Test_Project> LoadProjectsFromTesttable()
            {
                List<Test_Project> Test_projects_list = new List<Test_Project>();
                string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = "SELECT * FROM Test_table";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                            Test_Project Test_Project = new Test_Project(

                            reader.GetString(0),
                            reader.GetString(1),
                            reader.GetString(2),
                            reader.GetString(3),
                            reader.GetString(4),
                            reader.GetString(5),

                            reader.GetString(6));
                            Test_projects_list.Add(Test_Project);
                            }
                        }
                    }
                }

                return Test_projects_list;
            }
        public void CreateTestTable()
        {
            string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE Test_table(" +
                    // "PK_projects int PRIMARY KEY IDENTITY," +
                    "PK_projects nvarchar(10)," +
                    "Name nvarchar(10)," +
                    "Hours_planed nvarchar(10)," +
                    "Project_ID nvarchar(10)," +
                    "Start_date nvarchar(10)," +
                    "End_date nvarchar(10)," +
                    "Comment nvarchar(10))";
                
                
                    
                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();
                
            }
        }

        //a method to autogenerate test data for a list of projects
        public List<Test_Project> GenerateTestDataList()
        {


            List<Test_Project> Test_projects_list = new List<Test_Project>();
            Test_Project Test_Project = new Test_Project("Pro1", "1", "1", "1", "1", "1", "1");
            Test_projects_list.Add(Test_Project);
            Test_Project Test_Project2 = new Test_Project("Pro2", "2", "2", "2", "2", "2", "2");
            Test_projects_list.Add(Test_Project2);
            Test_Project Test_Project3 = new Test_Project("Pro", "3", "3", "3", "3", "3", "3");
            Test_projects_list.Add(Test_Project3);
            Test_Project Test_Project4 = new Test_Project("Pro", "4", "4", "4", "4", "4", "4");
            Test_projects_list.Add(Test_Project4);
            Test_Project Test_Project5 = new Test_Project("Pro", "5", "5", "5", "5", "5", "5");
            Test_projects_list.Add(Test_Project5);
            Test_Project Test_Project6 = new Test_Project("Proj6", "6", "6", "6", "6", "6", "6");
            Test_projects_list.Add(Test_Project6);
            Test_Project Test_Project7 = new Test_Project("Proj7", "7", "7", "7", "7", "7", "7");
            Test_projects_list.Add(Test_Project7);
            Test_Project Test_Project8 = new Test_Project("Pro8", "8", "8", "8", "8", "8", "8");
            Test_projects_list.Add(Test_Project8);
            Test_Project Test_Project9 = new Test_Project("Pro9", "9", "9", "9", "9", "9", "9");
            Test_projects_list.Add(Test_Project9);
            Test_Project Test_Project10 = new Test_Project("P10", "10", "10", "10", "10", "10", "10");
            Test_projects_list.Add(Test_Project10);
            Test_Project Test_Project11 = new Test_Project("t11", "11", "11", "11", "11", "11", "11");
            Test_projects_list.Add(Test_Project11);
            Test_Project Test_Project12 = new Test_Project("ct12", "12", "12", "12", "12", "12", "12");
            Test_projects_list.Add(Test_Project12);
            
            return Test_projects_list;
            
        }

        public void WriteTestToTestDB(List<Test_Project> Test_projects_list)
        {
       
        
            try
            {
                using (SqlConnection connection = new SqlConnection("Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;"))
                {
                    connection.Open();

                    //string sql = "INSERT INTO Test_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
                    //   "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";
                    foreach (Test_Project test_project in Test_projects_list)
                    {
                        string sql = "INSERT INTO Test_table (PK_projects,Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
                        "VALUES (@PK_projects,@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";
                        SqlCommand command = new SqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@PK_projects", test_project.PK_project);
                        command.Parameters.AddWithValue("@Project_name", test_project.Project_name);
                        command.Parameters.AddWithValue("@Project_ID", test_project.Project_number);
                        command.Parameters.AddWithValue("@Hours_planed", test_project.Hours_planed);
                        command.Parameters.AddWithValue("@Start_date", test_project.Start_date);
                        command.Parameters.AddWithValue("@End_date", test_project.End_date);
                        command.Parameters.AddWithValue("@Comment", test_project.Comment);
                        command.ExecuteNonQuery();
                    }

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("" + ex, "");

            }
        }

        public class Test_Project
        {
        public string PK_project { get; set; }
        public string? Project_name { get; set; }
        public string? Project_number { get; set; }
        public string? Hours_planed { get; set; }
        public string? Start_date { get; set; }
        public string? End_date { get; set; }
        public string? Comment { get; set; }

            public Test_Project(string pk_projects, string project_name, string hours_planed, string? project_number,
             string start_date, string end_date, string comment)
            {
            this.PK_project = pk_projects;
            this.Project_name = project_name;
            this.Project_number = project_number;
            this.Hours_planed = hours_planed;
            this.Start_date = start_date;
            this.End_date = end_date;
            this.Comment = comment;
            }
        }
        
        private void add_project_button_Click(object sender, RoutedEventArgs e)
        {
            Create_project_window create_project_window = new Create_project_window();
            create_project_window.Show();
        }

        private void projects_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

