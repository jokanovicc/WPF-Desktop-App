﻿using SF_19_2019_POP2020.Windows;
using SF_19_2019_POP2020.Windows.PacijentiProzori;
using SF_19_2019_POP2020.Windows.TerapijaProzori;
using SF19_2019_POP2020.Models;
using SF19_2019_POP2020.Windows;
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

namespace SF19_2019_POP2020
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {
        public HomeWindow()
        {
            InitializeComponent();
            Util.Instance.CitanjeEntiteta("korisnici.txt");
            Util.Instance.CitanjeEntiteta("lekari.txt");

        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            AllDoctors window = new AllDoctors();

            window.Show();
        }

        private void BtnPacijent_Click(object sender, RoutedEventArgs e)
        {
            PacijentiWindow pw = new PacijentiWindow();
            pw.ShowDialog();

        }

        private void BtnDomZdravlja_Click(object sender, RoutedEventArgs e)
        {
            DomoviZdravljaWindow dzw = new DomoviZdravljaWindow();
            dzw.ShowDialog();

        }

        private void BtnTermin_Click(object sender, RoutedEventArgs e)
        {
            TerminiWindow1 tw = new TerminiWindow1();
            tw.ShowDialog();
        }

        private void BtnAdresa_Click(object sender, RoutedEventArgs e)
        {
            AdreseWindow aw = new AdreseWindow();
            aw.ShowDialog();

        }

        private void BtnTerapije_Click(object sender, RoutedEventArgs e)
        {
            TerapijaWindow tw = new TerapijaWindow();
            tw.ShowDialog();

        }


        private void BtnAdministrator_Click(object sender, RoutedEventArgs e)
        {
            AdministratoriWindow aw = new AdministratoriWindow();
            aw.ShowDialog();

        }




    }
}
