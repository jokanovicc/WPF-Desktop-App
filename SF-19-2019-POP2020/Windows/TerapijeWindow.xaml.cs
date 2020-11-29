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
    /// Interaction logic for TerapijeWindow.xaml
    /// </summary>
    public partial class TerapijeWindow : Window
    {
        ICollectionView view;
        public TerapijeWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Terapije);
            dgTerapije.ItemsSource = view;
            dgTerapije.IsSynchronizedWithCurrentItem = true;


            dgTerapije.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
    }
}
