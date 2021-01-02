using SF19_2019_POP2020.Models;
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

namespace SF_19_2019_POP2020.Windows.PacijentiProzori
{
    /// <summary>
    /// Interaction logic for PacijentiPick.xaml
    /// </summary>
    public partial class PacijentiPick : Window
    {
        public enum Stanje { ADMINISTRACIJA, PREUZIMANJE };
        Stanje stanje;
        ICollectionView view;


        public Pacijent SelektovaniPacijent = null;

        public PacijentiPick(Stanje stanje = Stanje.ADMINISTRACIJA)
        {
            InitializeComponent();
            this.stanje = stanje;

            if (stanje == Stanje.PREUZIMANJE)
            {
                btnAdd.Visibility = System.Windows.Visibility.Collapsed;
                btnDelete.Visibility = System.Windows.Visibility.Collapsed;
                btnUpdate.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                btnPick.Visibility = System.Windows.Visibility.Hidden;
            }
            view = CollectionViewSource.GetDefaultView(Util.Instance.Pacijenti);
            view.Filter = PrikazFiltera;
            dgPacijenti.ItemsSource = view;
       //     dgPacijenti.IsSynchronizedWithCurrentItem = true;

            dgPacijenti.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }
        private bool PrikazFiltera(object obj)
        {
            return ((Pacijent)obj).Aktivan;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            SelektovaniPacijent = dgPacijenti.SelectedItem as Pacijent;
            this.DialogResult = true;
            this.Close();
        }
    }
}
