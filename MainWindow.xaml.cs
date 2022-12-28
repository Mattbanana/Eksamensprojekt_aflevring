using Eksamensprojekt_2nd.Models;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void project_view_button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Projects_view();
        }

        private void manager_view_button_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = new Project_manager_view();
        }
    }
}
