using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public class Potrawa
    {
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public string Image { get; set; }
        public string Trudnosc { get; set; }

        public Potrawa(string nazwa,string opis,string image,string trudnosc)
        {
            Nazwa = nazwa;
            Opis = opis;
            Image = image;
            Trudnosc = trudnosc;
        }
    }
}
