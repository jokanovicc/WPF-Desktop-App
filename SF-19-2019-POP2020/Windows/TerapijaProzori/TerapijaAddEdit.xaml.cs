using SF_19_2019_POP2020.Windows.DoktoriProzori;
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
    /// Interaction logic for TerapijaAddEdit.xaml
    /// </summary>
    public partial class TerapijaAddEdit : Window
    {
        Terapija terapija;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public TerapijaAddEdit(Terapija terapija, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.terapija = terapija;
            this.stanje = stanje;

            Random random = new Random();
            //      korisnik.ID = random.Next(1, 1000);
            terapija.Aktivan = true;
            tbOpis.DataContext = terapija;
          //  terapija.PacijentID = 836;
          //  terapija.DomZdravljaID = 641;
          //  tbAdresa.DataContext = terapija;
          //  tbDomZdravlja.DataContext = terapija;

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

        private void btnPicPacijent_Click(object sender, RoutedEventArgs e)
        {
            PacijentiPick gw = new PacijentiPick(PacijentiPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                terapija.PacijentID = gw.SelektovaniPacijent.ID;
            }
        }

        private void btnLekar_Click(object sender, RoutedEventArgs e)
        {
            LekariPick gw = new LekariPick(LekariPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                terapija.LekarID= gw.selektovaniLekar.ID;
            }
        }
    }
}

