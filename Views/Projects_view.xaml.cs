using Eksamensprojekt_2nd.Models;
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


            //CreateProjectTableInDB();
            //List<Project> project_list = Generate_ProjectList_with_Data();
            //WritelistToDB(project_list);

            

            List<Project> projects_list = new() ;
            projects_list = GetAllProjecttablefromDB();
            
            projects_listview.ItemsSource = projects_list;




            ///// //List<Test_Project> Test_projects_list_W_Testdata = GenerateTestDataList();
            // CreateTestTable();
            // WriteTestlistToTestDB(Test_projects_list_W_Testdata);
            // List<Test_Project> Test_projects_list = new List<Test_Project>();
            //List<Test_Project> Test_projects_list = LoadProjectsFromTestDBtable();
            //projects_listview.ItemsSource = Test_projects_list;

            //List<Test_Project> projects_list = Projects.LoadProjectsFromDBtable();
            
        }

        public void CreateProjectTableInDB()
        {
            string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE Project_table(" +
                    "PK_project int PRIMARY KEY IDENTITY," +
                    "FK_project_manager)," +
                    "Name nvarchar(100)," +
                    "Project_ref nvarchar(100)," +
                    "Hours_planed int," +
                    "Start_date DateTime," +
                    "End_date DateTime," +
                    "Comment nvarchar(1000))";

                SqlCommand command = new SqlCommand(sql, connection);
                command.ExecuteNonQuery();

            }
        }

        public List<Project> Generate_ProjectList_with_Data()

        {
            List<Project> projects_list = new List<Project>();

            foreach (int i in Enumerable.Range(1, 10))
            {

                projects_list.Add(new Project(
                    "Project_" + i,
                    "Project_ID_" + i,
                    new Random().Next(100, 150),
                    GetRandomNearFutureDate(),
                    GetRandomFarFutureDate(),
                    "Comment_" + i));
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
                    string sql = "INSERT INTO Project_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
                    "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";

                    SqlCommand command = new SqlCommand(sql, connection);

                    command.Parameters.AddWithValue("@Project_name", project.Project_name);
                    command.Parameters.AddWithValue("@Project_ID", project.Project_ref);
                    command.Parameters.AddWithValue("@Hours_planed", project.Hours_planed);
                    command.Parameters.AddWithValue("@Start_date", project.Start_date);
                    command.Parameters.AddWithValue("@End_date", project.End_date);
                    command.Parameters.AddWithValue("@Comment", project.Comment);

                    command.ExecuteNonQuery();
                }

            }

        }

        public static List<Project> GetAllProjecttablefromDB()
        {
            List<Project> projects_list_from_DB = new List<Project>();
            string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Project_table";
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        //if (projects_list_from_DB. > 0)
                        //{
                        //    projects_list_from_DB.Clear();
                        //}
                        while (reader.Read())
                        {
                            Project project = new Project(
                             reader.GetString(1),
                             reader.GetString(2),
                             reader.GetInt32(3),
                             reader.GetDateTime(4),
                             reader.GetDateTime(5),
                             reader.GetString(6));

                            projects_list_from_DB.Add(project);
                        }
                    }
                }
            }

            return projects_list_from_DB;
        }

        ////    private List<Test_Project> LoadProjectsFromTestDBtable()
        ////    {
        ////        List<Test_Project> Test_projects_list = new List<Test_Project>();
        ////        string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";
        ////        using (SqlConnection connection = new SqlConnection(connectionString))
        ////        {
        ////            connection.Open();

        ////            string sql = "SELECT * FROM Test_table";
        ////            using (SqlCommand command = new SqlCommand(sql, connection))
        ////            {
        ////                using (SqlDataReader reader = command.ExecuteReader())
        ////                {
        ////                    while (reader.Read())
        ////                    {
        ////                    Test_Project Test_Project = new Test_Project(


        ////                    reader.GetString(1),
        ////                    reader.GetInt32(2),
        ////                    reader.GetString(3),
        ////                    reader.GetDateTime(4),
        ////                    reader.GetDateTime(5),

        ////                    reader.GetString(6));
        ////                    Test_projects_list.Add(Test_Project);
        ////                    }
        ////                }
        ////            }
        ////        }

        ////        return Test_projects_list;
        ////    }
        ////public void CreateTestTable()
        ////{
        ////    string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";

        ////    using (SqlConnection connection = new SqlConnection(connectionString))
        ////    {
        ////        connection.Open();
        ////        string sql = "CREATE TABLE Test_table(" +
        ////            "PK_projects int PRIMARY KEY IDENTITY," +
        ////            //"PK_projects nvarchar(10)," +
        ////            "Name nvarchar(100)," +
        ////            "Hours_planed int," +
        ////            "Project_ID nvarchar(100)," +
        ////            "Start_date DateTime," +
        ////            "End_date DateTime," +
        ////            "Comment nvarchar(1000))";



        ////        SqlCommand command = new SqlCommand(sql, connection);
        ////        command.ExecuteNonQuery();

        ////    }
        ////}

        ////a method to autogenerate test data for a list of projects
        //public List<Test_Project> GenerateTestDataList()

        //{
        //    List<Test_Project> Test_projects_list = new List<Test_Project>();

        //    //a foreach-loop that genrates a list of Test_Project(nvarchar(100) "Project_2", int "20" (random between 100 and 150), nvarchar(100) (random funny text), dateonly "01-01-2020" (near future dates), dateonly "01-01-2020"(far future date), nvarchar(100) "Comment_2"(some fun comment)) with test data

        //    foreach (int i in Enumerable.Range(1, 10))
        //    {

        //        Test_projects_list.Add(new Test_Project("Project_" + i, new Random().Next(100, 150), "Project_ID_" + i, 
        //            GetRandomNearFutureDate(), GetRandomFarFutureDate(), "Comment_" + i)) ;
        //    }



        //    return Test_projects_list;

        //    static DateTime GetRandomNearFutureDate()
        //    {
        //        var today = DateTime.Today;
        //        return today.AddDays(new Random().Next(1, 30));
        //    }

        //    // Method to generate a random date in the far future
        //    static DateTime GetRandomFarFutureDate()
        //    {
        //        var today = DateTime.Today;
        //        return today.AddDays(new Random().Next(365, 730));
        //    }



        //    //Test_Project Test_Project_1 = new Test_Project("Project_1", "10", "1", "01-01-2020", "01-01-2020", "Comment_1");

        //    //Test_Project Test_Project_2 = new Test_Project("Project_2", "20", "2", "01-01-2020", "01-01-2020", "Comment_2");
        //    //Test_Project Test_Project_3 = new Test_Project("Project_3", "30", "3", "01-01-2020", "01-01-2020", "Comment_3");
        //    //Test_Project Test_Project_4 = new Test_Project("Project_4", "40", "4", "01-01-2020", "01-01-2020", "Comment_4");
        //    //Test_Project Test_Project_5 = new Test_Project("Project_5", "50", "5", "01-01-2020", "01-01-2020", "Comment_5");
        //    //Test_Project Test_Project_6 = new Test_Project("Project_6", "60", "6", "01-01-2020", "01-01-2020", "Comment_6");
        //    //Test_Project Test_Project_7 = new Test_Project("Project_7", "70", "7", "01-01-2020", "01-01-2020", "Comment_7");
        //    //Test_Project Test_Project_8 = new Test_Project("Project_8", "80", "8", "01-01-2020", "01-01-2020", "Comment_8");
        //    //Test_Project Test_Project_9 = new Test_Project("Project_9", "90", "9", "01-01-2020", "01-01-2020", "Comment_9");
        //    //Test_Project Test_Project_10 = new Test_Project("Project_10", "100", "10", "01-01-2020", "01-01-2020", "Comment_10");
        //    //Test_Project Test_Project_11 = new Test_Project("Project_11", "110", "11", "01-01-2020", "01-01-2020", "Comment_11");
        //    //Test_Project Test_Project_12 = new Test_Project("Project_12", "120", "12", "01-01-2020", "01-01-2020", "Comment_12");



        //}


        ////public void WriteTestlistToTestDB(List<Test_Project> Test_projects_list)
        ////{



        ////        using (SqlConnection connection = new SqlConnection("Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;"))
        ////        {
        ////            connection.Open();

        ////            //string sql = "INSERT INTO Test_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
        ////            //   "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";
        ////            foreach (Test_Project test_project in Test_projects_list)
        ////            {
        ////                string sql = "INSERT INTO Test_table (Name,Project_ID,Hours_planed,Start_date,End_date,Comment) " +
        ////                "VALUES (@Project_name,@Project_ID, @Hours_planed, @Start_date, @End_date, @Comment)";
        ////                SqlCommand command = new SqlCommand(sql, connection);

        ////                command.Parameters.AddWithValue("@Project_name", test_project.Project_name);
        ////                command.Parameters.AddWithValue("@Project_ID", test_project.Project_number);
        ////                command.Parameters.AddWithValue("@Hours_planed", test_project.Hours_planed);
        ////                command.Parameters.AddWithValue("@Start_date", test_project.Start_date);
        ////                command.Parameters.AddWithValue("@End_date", test_project.End_date);
        ////                command.Parameters.AddWithValue("@Comment", test_project.Comment);
        ////                command.ExecuteNonQuery();
        ////            }

        ////        }

        ////}

        //public class Test_Project
        //{

        //public string? Project_name { get; set; }
        //public string Project_number { get; set; }
        //public int Hours_planed { get; set; }
        //public DateTime Start_date { get; set; }
        //public DateTime End_date { get; set; }
        //public string Comment { get; set; }

        //    public Test_Project( string project_name, int hours_planed, string project_number,
        //     DateTime start_date, DateTime end_date, string comment)
        //    {
        //    //this.PK_project = pk_projects;
        //    this.Project_name = project_name;
        //    this.Project_number = project_number;
        //    this.Hours_planed = hours_planed;
        //    this.Start_date = start_date;
        //    this.End_date = end_date;
        //    this.Comment = comment;
        //    }
        //}

        private void add_project_button_Click(object sender, RoutedEventArgs e)
        {
            Create_project_window create_project_window = new Create_project_window();
            create_project_window.Show();
        }

        private void projects_listview_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Project selectedItem = (Project)projects_listview.SelectedItem;
                MessageBox.Show("valg:" + selectedItem);
            }
            catch (Exception)
            {
                MessageBox.Show("ingen valg");
                throw;
            }
            

            
            
            
            
            
        }
    }
}

