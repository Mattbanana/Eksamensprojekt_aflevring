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
    /// Interaction logic for Create_project_window.xaml
    /// </summary>
    public partial class Create_project_window : Window
    {
        public Create_project_window()
        {
            InitializeComponent();
            
            
            Name_input_project_textbox.Text = "Project name";
            Project_ref_input_project_textbox.Text = "Project ref";
            hours_planned_input_project_textbox.Text = "135";
            Start_date_project_textbox.Text = "11-02-2025";
            End_date_project_textbox.Text = "11-02-2026";
            comment_input_project_textbox.Text = "comment here";



        }

        private void Create_project_manager_button_Click(object sender, RoutedEventArgs e)
        {

            
            //var p_name = Name_input_project_textbox.Text;
            //var p_id = Project_ref_input_project_textbox.Text;
            var h_planed = hours_planned_input_project_textbox.Text;
            //var s_date = Start_date_project_textbox.Text;
            //var e_date = End_date_project_textbox.Text;
            //var comm = comment_input_project_textbox.Text;

            Double conv_h_planed = Convert.ToDouble(h_planed);

            Project Input_project = new Project(0, Name_input_project_textbox.Text, Project_ref_input_project_textbox.Text,
                conv_h_planed, Start_date_project_textbox.Text, End_date_project_textbox.Text, comment_input_project_textbox.Text);

           // Input_project.CreateTable();

            Input_project.GreateProject();

            

            //Input_project.Testdataaccess();
        }
    }
}
