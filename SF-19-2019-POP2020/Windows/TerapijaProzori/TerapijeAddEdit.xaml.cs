using SF_19_2019_POP2020.Windows.LekariProzori;
using SF_19_2019_POP2020.Windows.PacijentiProzori;
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

namespace SF_19_2019_POP2020.Windows.TerapijaProzori
{
    /// <summary>
    /// Interaction logic for TerapijeAddEdit.xaml
    /// </summary>
    public partial class TerapijeAddEdit : Window
    {
        Terapija terapija;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public TerapijeAddEdit(Terapija terapija, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();
            this.terapija = terapija;
            this.stanje = stanje;

            terapija.Aktivan = true;
            tbOpis.DataContext = terapija;
            tbLekari.DataContext = terapija;
            tbPacijent.DataContext = terapija;
            tbSifra.DataContext = terapija;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                Aplikacija.Instance.Terapije.Add(terapija);
            }
            this.Close();
        }

        private void btnPickLekar_Click(object sender, RoutedEventArgs e)
        {
            LekariPick gw = new LekariPick(LekariPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                terapija.Lekar = gw.SelektovaniLekar;
                /*
                 * Da bi se grad promenio i u text boxu mora Fakultet da implementira INotifyPropertyChanged 
                 * i da "javi" putem dogadjaja kada se desila promena u svojstvu Fakultet
                 * 
                 * */
            }
        }
        private void btnPickPacijent_Click(object sender, RoutedEventArgs e)
        {
            PacijentiPick gw = new PacijentiPick(PacijentiPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                terapija.Pacijent = gw.SelektovaniPacijent;
                /*
                 * Da bi se grad promenio i u text boxu mora Fakultet da implementira INotifyPropertyChanged 
                 * i da "javi" putem dogadjaja kada se desila promena u svojstvu Fakultet
                 * 
                 * */
            }
        }

    }
}
