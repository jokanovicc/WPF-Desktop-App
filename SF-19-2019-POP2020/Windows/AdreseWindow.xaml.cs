using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace SF_19_2019_POP2020.Windows
{
    /// <summary>
    /// Interaction logic for AdreseWindow.xaml
    /// </summary>
    public partial class AdreseWindow : Window
    {
        ICollectionView view;
        public AdreseWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Adrese);
            dgAdresa.ItemsSource = view;
            dgAdresa.IsSynchronizedWithCurrentItem = true;


            dgAdresa.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
    }
}
