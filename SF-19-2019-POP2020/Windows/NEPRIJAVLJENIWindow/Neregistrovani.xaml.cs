using SF_19_2019_POP2020.Models;
using SF19_2019_POP2020.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
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

namespace SF_19_2019_POP2020.Windows.NEPRIJAVLJENIWindow
{
    /// <summary>
    /// Interaction logic for Neregistrovani.xaml
    /// </summary>
    public partial class Neregistrovani : Window

    {
        ICollectionView view1;
        ICollectionView view2;
        ICollectionView view3;
        public Neregistrovani()
        {
           
            InitializeComponent();
            Util.Instance.CitanjeEntiteta();
            view1 = CollectionViewSource.GetDefaultView(Util.Instance.Adrese);
            dgAdresa.ItemsSource = view1;
            dgAdresa.IsSynchronizedWithCurrentItem = true;
            dgAdresa.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
            //dgAdresa.Columns[1].Visibility = Visibility.Collapsed;


            view2 = CollectionViewSource.GetDefaultView(Util.Instance.DomoviZdravlja);
            dgDomZdravlja.ItemsSource = view2;
            dgDomZdravlja.IsSynchronizedWithCurrentItem = true;
            dgDomZdravlja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            view3 = CollectionViewSource.GetDefaultView(Util.Instance.Lekari);
            dgLekari.ItemsSource = view3;
            dgLekari.IsSynchronizedWithCurrentItem = true;
            dgLekari.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }


        private void DGAdrese_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Aktivan"))
                e.Column.Visibility = Visibility.Collapsed;
        }

        private void DGL_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Aktivan") || e.PropertyName.Equals("ID") || e.PropertyName.Equals("JMBG") || e.PropertyName.Equals("Lozinka") || e.PropertyName.Equals("Email") )
                e.Column.Visibility = Visibility.Collapsed;
        }

        private void DGDZ_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyName.Equals("Aktivan"))
                e.Column.Visibility = Visibility.Collapsed;
        }

        private void btn_DomZdravlja(object sender, RoutedEventArgs e)
        {
            OdaberiDomZdravljaMesto izd = new OdaberiDomZdravljaMesto();
            izd.Show();
        }

    }
}