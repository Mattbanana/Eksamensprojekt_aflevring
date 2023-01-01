using Eksamensprojekt_2nd.Models;
using Microsoft.VisualBasic;
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
    /// Interaction logic for Create_project_window.xaml
    /// </summary>
    /// init default values for the form inputs and creates a new project
    /// and writes it to the database through a method call
    public partial class Create_project_window : Window
    {
        public Create_project_window()
        {
            InitializeComponent();

            //Init values for Form
            Name_input_project_textbox.Text = "Project name";
            Project_ref_input_project_textbox.Text = "Project ref";
            hours_planned_input_project_textbox.Text = "135";
            Start_date_project_textbox.Text = "11-02-2025";
            End_date_project_textbox.Text = "11-02-2026";
            comment_input_project_textbox.Text = "comment here";
        }

        private void Create_project_manager_button_Click(object sender, RoutedEventArgs e)
        {
            //this event creates a new project and adds it to the database
            //it also checks if the input is valid and creates a new project manager if it is
            //if the input is not valid it will show an error message
            //there is a method call for CreateProjectInDBTable()
            //to query the database with the new project named input_project

            Project project_from_input = new Project( 
                Name_input_project_textbox.Text, 
                Project_ref_input_project_textbox.Text,
                Convert.ToInt32(hours_planned_input_project_textbox.Text), 
                DateTime.Parse(Start_date_project_textbox.Text), 
                DateTime.Parse(End_date_project_textbox.Text), 
                comment_input_project_textbox.Text);

                project_from_input.CreateProjectInDBtable();

        }
    }
}
