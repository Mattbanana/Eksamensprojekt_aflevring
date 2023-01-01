using Eksamensprojekt_2nd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Eksamensprojekt_2nd.Views
{
    /// <summary>
    /// Interaction logic for Create_project_manager_window.xaml
    /// </summary>
    public partial class Create_project_manager_window : Window
    {
        public Create_project_manager_window()
        {
            InitializeComponent();

            //Init values for Form
            Name_input_project_manager_textbox.Text = "Project manager name";
            Employee_input_project_manager_textbox.Text = "Employee ref";
            Phone_number_input_project_manager_textbox.Text = "7574839999";
            Email_input_project_manager_textbox.Text = "Email@dinmor";
            comment_input_project_manager_textbox.Text = "comment here";
            Hours_available_per_month_input_project_manager_textbox.Text = "135";
        }

        private void Create_project_manager_button_Click(object sender, RoutedEventArgs e)
        {

            //this event creates a new project manager and adds it to the database
            //it also checks if the input is valid and creates a new project manager if it is
            //if the input is not valid it will show an error message
            //there is a method call for CreateProjectManagerInDBTable()
            //to query the database with the new project manager named input_project_manager
            Project_manager input_project_manager = new Project_manager(
                Name_input_project_manager_textbox.Text,
                Employee_input_project_manager_textbox.Text,
                Phone_number_input_project_manager_textbox.Text,
                Email_input_project_manager_textbox.Text,
                comment_input_project_manager_textbox.Text,
                Convert.ToInt32(Hours_available_per_month_input_project_manager_textbox.Text));

                input_project_manager.CreateProjectManagerInDBTable();


        }
    }
}
