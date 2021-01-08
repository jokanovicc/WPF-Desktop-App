using SF_19_2019_POP2020.Models;
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

namespace SF_19_2019_POP2020.Windows.DoktoriProzori
{
    /// <summary>
    /// Interaction logic for DoktoriPick.xaml
    /// </summary>
    public partial class LekariPick : Window
    {
        public enum Stanje { ADMINISTRACIJA, PREUZIMANJE };
        Stanje stanje;
        ICollectionView view;
        public Lekar selektovaniLekar = null;

        public LekariPick(Stanje stanje = Stanje.ADMINISTRACIJA)
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
            //   Util.Instance.CitanjeEntiteta();
            //view = CollectionViewSource.GetDefaultView(Util.Instance.Lekari);
          //  view.Filter = PrikazFiltera;
            dgDoktori.ItemsSource = Util.Instance.Lekari;
            dgDoktori.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool PrikazFiltera(object obj)
        {
            return ((Lekar)obj).Aktivan;
        }
        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            selektovaniLekar = dgDoktori.SelectedItem as Lekar;
            this.DialogResult = true;
            this.Close();
        }
    }
}
