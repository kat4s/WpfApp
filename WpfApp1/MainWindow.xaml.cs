using System;
using System.Collections.Generic;
using System.Windows;
using System.IO;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var products1 = GetProducts();

            if (products1.Count > 0)
                ListViewProducts.ItemsSource = products1;
        }

        private List<Potrawa> GetProducts()
        {
            string relativePath = System.IO.Path.Combine(Environment.CurrentDirectory, "przepisy.txt");
            var lista_przepisow = new List<Potrawa>();
            using (StreamReader reader = new StreamReader(relativePath))
            {
                string linia;
                while((linia = reader.ReadLine()) != null){
                    var wartosc = linia.Split(';');
                    lista_przepisow.Add(new Potrawa(wartosc[0], wartosc[1], wartosc[2], wartosc[3]));

                }
            }
            return lista_przepisow;
            
        }
        private void Dodajbtn_Click(object sender,RoutedEventArgs e)
        {
            Dodaj windowdodaj = new Dodaj();
            windowdodaj.Show();
        }
        private void pokaz_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            var products1 = GetProducts();

            if (products1.Count > 0)
                ListViewProducts.ItemsSource = products1;
        }
    }

}