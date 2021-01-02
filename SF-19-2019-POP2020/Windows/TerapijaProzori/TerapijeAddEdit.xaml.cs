using SF_19_2019_POP2020.Services;
using SF_19_2019_POP2020.Windows.DoktoriProzori;
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
            Random random = new Random();
         //   terapija.Sifra = random.Next(1, 1000);
            terapija.Aktivan = true;
          //  terapija.LekarID = 14;
         //   terapija.PacijentID = 323;
            tbOpis.DataContext = terapija;
            tbLekari.DataContext = terapija;
            tbPacijent.DataContext = terapija;
           // tbSifra.DataContext = terapija;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                Util.Instance.Terapije.Add(terapija);
                Util.Instance.SacuvajEntitet(terapija);
            }
            if (stanje == Stanje.IZMENA)
            {
                //Util.Instance.Adrese.Add(adresa);
                Util.Instance.updateTerapija(terapija);


            }
            this.Close();
        }

        private void btnPickLekar_Click(object sender, RoutedEventArgs e)
        {
            DoktoriPick gw = new DoktoriPick(DoktoriPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
               terapija.LekarID = gw.selektovaniLekar.ID;
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
                terapija.PacijentID = gw.SelektovaniPacijent.ID;
                /*
                 * Da bi se grad promenio i u text boxu mora Fakultet da implementira INotifyPropertyChanged 
                 * i da "javi" putem dogadjaja kada se desila promena u svojstvu Fakultet
                 * 
                 * */
            }
        }

    }
}
