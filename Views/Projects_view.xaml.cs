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
    /// View class that loads a list of all the projects from the database and displays them in a list named projects_listview
    /// the class also contains a button that makes a new window pop-up, where the user can create a new project
    /// </summary>
    public partial class Projects_view : UserControl
    {
        public Projects_view()
        {   
            InitializeComponent();
            
            projects_listview.ItemsSource = Project_repo.GetAllProjectTableDB();
        }


        private void add_project_button_Click(object sender, RoutedEventArgs e)
        {
            //this event makes a new window pop-up, where the user can create a new project
            Create_project_window create_project_window = new Create_project_window();
            create_project_window.Show();
        }
    }
}

