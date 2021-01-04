using SF19_2019_POP2020;
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

namespace SF_19_2019_POP2020
{
    /// <summary>
    /// Interaction logic for Glavna.xaml
    /// </summary>
    public partial class Glavna : Window
    {
        public Glavna()
        {
            InitializeComponent();
        }
        private void btnAdmin_click(object sender, RoutedEventArgs e)
        {
            HomeWindow window = new HomeWindow();

            window.Show();
        }

        private void btnNeregistrovani_click(object sender, RoutedEventArgs e)
        {
            HomeWindow window = new HomeWindow();

            window.Show();
        }
    }
}
