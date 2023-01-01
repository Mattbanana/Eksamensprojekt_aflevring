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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eksamensprojekt_2nd.Views
{
    /// <summary>
    /// Interaction logic for Project_manager_view.xaml
    /// </summary>
    public partial class Project_manager_view : UserControl
    {
        public Project_manager_view()
        {
            InitializeComponent();

        }

        private void add_manager_button_Click(object sender, RoutedEventArgs e)
        {
            //this event makes a new window pop-up, where the user can create a new project_manager
            Create_project_manager_window create_project_manager_window = new Create_project_manager_window();
            create_project_manager_window.Show();
            
        }
    }
}
