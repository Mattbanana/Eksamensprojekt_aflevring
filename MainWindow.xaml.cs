using Eksamensprojekt_2nd.Models;
using Eksamensprojekt_2nd.Viewmodels;
using Eksamensprojekt_2nd.Views;
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

namespace Eksamensprojekt_2nd
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            
           /// midlertidig hardcoded liste med projekter, til test af program. Skal komme fra sql server senere.
            List<Project> projects = new List<Project>() ;

            projects.Add(new Project("project1", "1", 300, "2015-01-02", "2016-02-11", "sur som fanden ham selv"));
            projects.Add(new Project("project2", "2", 300, "2015-03-12", "2016-02-11", "glad for fransk nugat"));
            projects.Add(new Project("project3", "3", 300, "2015-04-8", "2016-02-11", "knap så glad for fransk nugat"));


            /// midlertidig hardcoded liste med projekt managers, til test af program. Skal komme fra sql server senere.
            List<Project_manager> project_Managers = new List<Project_manager>();

            project_Managers.Add(new Project_manager("project manager 1", "sk-45783", "+455694837", "fisk@g.com","generalt ret høj", 130));
            project_Managers.Add(new Project_manager("project manager 2", "st-483", "+45556837", "fiskestang@g.com", "knap så glad for fransk nugat", 140));
            project_Managers.Add(new Project_manager("project manager 2", "st-483", "+4555683745", "fiskestangfang@g.com", "nugat nugat nugat", 120));



        }
        /// menu knap i toppen til at
        private void project_view_button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Projects_viewmodel();
        }

        private void manager_view_button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new Project_managers_viewmodel();
        }
    }
}
