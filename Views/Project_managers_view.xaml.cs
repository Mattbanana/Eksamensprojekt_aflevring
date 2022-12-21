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
            
            

            /// midlertidig hardcoded liste med projekt managers, til test af program. Skal komme fra sql server senere.
            List<Project_manager> project_Managers = new List<Project_manager>();

            project_Managers.Add(new Project_manager("project manager 1", "sk-45783", "+455694837", "fisk@g.com", "generalt ret høj", 130));
            project_Managers.Add(new Project_manager("project manager 2", "st-483", "+45556837", "fiskestang@g.com", "knap så glad for fransk nugat", 140));
            project_Managers.Add(new Project_manager("project manager 2", "st-483", "+4555683745", "fiskestangfang@g.com", "nugat nugat nugat", 120));

            
            manager_list.ItemsSource = project_Managers;

        }

        private void add_manager_button_Click(object sender, RoutedEventArgs e)
        {
            Create_project_manager_window create_project_manager_window = new Create_project_manager_window();
            create_project_manager_window.Show();
            
        }
    }
}
