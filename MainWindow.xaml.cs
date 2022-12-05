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
        }

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
