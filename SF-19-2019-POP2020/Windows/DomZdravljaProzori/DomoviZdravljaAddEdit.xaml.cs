using SF_19_2019_POP2020.Windows.AdresaProzori;
using SF19_2019_POP2020.Models;
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

namespace SF_19_2019_POP2020.Windows.DomZdravljaProzori
{
    /// <summary>
    /// Interaction logic for DomoviZdravljaAddEdit.xaml
    /// </summary>
    public partial class DomoviZdravljaAddEdit : Window
    {

        DomZdravlja domZdravlja;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public DomoviZdravljaAddEdit(DomZdravlja domZdravlja, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();
            this.domZdravlja = domZdravlja;
            this.stanje = stanje;

            domZdravlja.Aktivan = true;
            tbSifra.DataContext = domZdravlja;
            tbNaziv.DataContext = domZdravlja;
            tbAdresa.DataContext = domZdravlja;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                Aplikacija.Instance.DomoviZdravlja.Add(domZdravlja);
            }
            this.Close();
        }

        private void btnPicAdresa_Click(object sender, RoutedEventArgs e)
        {
            AdresaPick gw = new AdresaPick(AdresaPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                domZdravlja.Adresa = gw.SelektovanaAdresa;
                /*
                 * Da bi se grad promenio i u text boxu mora Fakultet da implementira INotifyPropertyChanged 
                 * i da "javi" putem dogadjaja kada se desila promena u svojstvu Fakultet
                 * 
                 * */
            }
        }
    }
}
