using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy Dodaj.xaml
    /// </summary>
    public partial class Dodaj : Window
    {
        string pathh = "x";
        private string[] trudnosc = { "Łatwy", "Średni", "Trudny" };
        public Dodaj()
        {
            InitializeComponent();
            foreach (string tr in trudnosc)
            {
                poziom_trudnosci.Items.Add(tr);
            }
            poziom_trudnosci.Text = poziom_trudnosci.Items[0] as string;
        }
        private void Slider_ValueChanged(object sender,RoutedPropertyChangedEventArgs<double> e)
        {
            SliderV.Content = Slider.Value.ToString();
        }
        private void Dodaj_zdj_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Image files|*.jpg;*.png";
            openDialog.FilterIndex = 1;
            if (openDialog.ShowDialog() == true)
            {
                pathh = openDialog.FileName;
            }
        }
        private void Dodaj_przep_Click(object sender, RoutedEventArgs e)
        {
            if (pathh == "x")
            {
                MessageBox.Show("Nie wybrałeś obrazka");
            }
            else
            {
                string relativePath = System.IO.Path.Combine(Environment.CurrentDirectory, "przepisy.txt");
                using (var writer = new StreamWriter(relativePath, true))
                {
                    string tmp;
                    tmp = nazwap.Text + ";" + tekst.Text + ";" + pathh + ";Trudność: " + poziom_trudnosci.Text + ", czas przygotowania " + SliderV.Content + " min";
                    writer.WriteLine(tmp);
                    writer.Close();
                    MessageBox.Show("Przepis został zapisany");
                }
            }


        }
    }
}
