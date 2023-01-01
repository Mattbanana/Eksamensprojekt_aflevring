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
            projects_list = Project_repo.GetAllProjectTableDB();
            
            projects_listview.ItemsSource = projects_list;
        }

        public void CreateProjectTableInDB()
        {
            string connectionString = "Server=10.56.8.37;Database=DB20;User Id=STUDENT20;Password= OPENDB_20;";


            //try catch


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string sql = "CREATE TABLE Project_table(" +
                    "PK_project int PRIMARY KEY IDENTITY," +
                    "FK_project_manager int," +
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

        private void add_project_button_Click(object sender, RoutedEventArgs e)
        {
            Create_project_window create_project_window = new Create_project_window();
            create_project_window.Show();
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


    }
}

