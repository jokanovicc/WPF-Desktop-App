﻿using SF_19_2019_POP2020.Models;
using SF_19_2019_POP2020.Windows.AdresaEditUpdate;
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

namespace SF_19_2019_POP2020.Windows
{
    /// <summary>
    /// Interaction logic for AdreseWindow.xaml
    /// </summary>
    public partial class AdreseWindow : Window
    {
        ICollectionView view;
        public AdreseWindow()
        {
            InitializeComponent();
            view = CollectionViewSource.GetDefaultView(Aplikacija.Instance.Adrese);
            dgAdresa.ItemsSource = view;
            dgAdresa.IsSynchronizedWithCurrentItem = true;


            dgAdresa.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Adresa selektovanaAdresa = view.CurrentItem as Adresa;
                Aplikacija.Instance.Adrese.Remove(selektovanaAdresa);
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Adresa novaAdresa = new Adresa();
            AdresaEditAddDelete few = new AdresaEditAddDelete(novaAdresa);
            few.ShowDialog();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Adresa selektovanaAdresa = view.CurrentItem as Adresa; //preuzimanje selektovane adrese

            if (selektovanaAdresa != null)//ako je neki fakultet selektovan
            {
                //napravimo kopiju trenutnih vrednosti u objektu,  da bi ih mogli preuzeti ako korisnik ponisti napravljenje izmene
                Adresa old = (Adresa)selektovanaAdresa.Clone();
                AdresaEditAddDelete few = new AdresaEditAddDelete(selektovanaAdresa,
                    AdresaEditAddDelete.Stanje.IZMENA);
                if (few.ShowDialog() != true) //ako je kliknuo cancel, ponistavaju se izmene nad objektom
                {

                    //pronadjemo indeks selektovanog fakulteta
                    int index = Aplikacija.Instance.Adrese.IndexOf(
                        selektovanaAdresa);
                    //vratimo vrednosti njegovih atributa na stare vrednosti, jer je izmena ponistena
                    Aplikacija.Instance.Adrese[index] = old;
                }
            }
        }



    }
}