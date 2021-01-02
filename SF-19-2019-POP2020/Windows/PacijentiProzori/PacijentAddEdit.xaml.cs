﻿using SF_19_2019_POP2020.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SF_19_2019_POP2020.Windows.PacijentiProzori
{
    /// <summary>
    /// Interaction logic for PacijentAddEdit.xaml
    /// </summary>
    public partial class PacijentAddEdit : Window
    {
        Pacijent korisnik;
        public enum Stanje { DODAVANJE, IZMENA };
        Stanje stanje;

        public PacijentAddEdit(Pacijent korisnik, Stanje stanje = Stanje.DODAVANJE)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.stanje = stanje;

            tbPol.ItemsSource = Enum.GetValues(typeof(EPol)).Cast<EPol>();
            Random random = new Random();
        //    korisnik.ID = random.Next(1, 1000);
            korisnik.Aktivan = true;
            korisnik.AdresaID = 836;
            tbLozinka.DataContext = korisnik;
            tbIme.DataContext = korisnik;
            tbEmail.DataContext = korisnik;
            tbIme.DataContext = korisnik;
            tbJmbg.DataContext = korisnik;
            tbPol.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbPol.DataContext = korisnik;
            tbAdresa.DataContext = korisnik;
            
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            if (stanje == Stanje.DODAVANJE)
            {
                Util.Instance.Pacijenti.Add(korisnik);
                Util.Instance.SacuvajEntitet(korisnik);
            }
            if (stanje == Stanje.IZMENA)
            {
                //Util.Instance.Adrese.Add(adresa);
                Util.Instance.updatePacijent(korisnik);


            }
            this.Close();
        }

        private void btnPicAdresa_Click(object sender, RoutedEventArgs e)
        {
           // Util.Instance.CitanjeEntiteta();
            AdresaPick gw = new AdresaPick(AdresaPick.Stanje.PREUZIMANJE);
            if (gw.ShowDialog() == true)
            {
                korisnik.AdresaID = gw.SelektovanaAdresa.SifraAdrese;
            }
        }

    }
}
