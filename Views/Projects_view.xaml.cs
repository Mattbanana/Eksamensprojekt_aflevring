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
    /// Interaction logic for Projects_view.xaml
    /// </summary>
    public partial class Projects_view : UserControl
    {
        public Projects_view()
        {
            InitializeComponent();

            /// midlertidig hardcoded liste med projekter, til test af program. Skal komme fra sql server senere.
            List<Project> projects = new List<Project>();

            projects.Add(new Project("project1", "1", 300, "2015-01-02", "2016-02-11", "sur som fanden ham selv"));
            projects.Add(new Project("project2", "2", 300, "2015-03-12", "2016-02-11", "glad for fransk nugat"));
            projects.Add(new Project("project3", "3", 300, "2015-04-8", "2016-02-11", "knap så glad for fransk nugat"));
        }
    }
}
