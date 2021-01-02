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

namespace SF_19_2019_POP2020.Windows.DomZdravljaProzori
{
    /// <summary>
    /// Interaction logic for DomZdravljaPick.xaml
    /// </summary>
    public partial class DomZdravljaPick : Window
    {
        public enum Stanje { ADMINISTRACIJA, PREUZIMANJE };
        Stanje stanje;
        ICollectionView view;

        public DomZdravlja SelektovaniDomZdravlja = null;

        public DomZdravljaPick(Stanje stanje = Stanje.ADMINISTRACIJA)
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
            view = CollectionViewSource.GetDefaultView(Util.Instance.DomoviZdravlja);
            view.Filter = PrikazFiltera;
            dgDomoviZdravlja.ItemsSource = view;

            dgDomoviZdravlja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool PrikazFiltera(object obj)
        {
            return ((DomZdravlja)obj).Aktivan;
        }
        private void btnPick_Click(object sender, RoutedEventArgs e)
        {
            SelektovaniDomZdravlja = dgDomoviZdravlja.SelectedItem as DomZdravlja;
            this.DialogResult = true;
            this.Close();
        }
    }
}
