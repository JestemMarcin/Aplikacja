using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    public class Osoba 
    {
        private string plec;
        private string imie;
        private string nazwisko;
        private int wiek;
        private int id;
        public DaneAdresowe adres;
        public Osoba(string imie, string nazwisko, int wiek, string plec, string kodpoczt, string miasto, string ulica, int nrdomu, int nrmieszkania,int id) 
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.Wiek = wiek;
            this.Plec = plec;
            this.Id = id;
            this.adres = new DaneAdresowe(kodpoczt, miasto, ulica, nrdomu, nrmieszkania);
        }
        public Osoba() { }
        

        public string Imie { get => imie; set => imie = value; }
        public string Nazwisko { get => nazwisko; set => nazwisko = value; }
        public int Wiek { get => wiek; set => wiek = value; }
        public string Plec { get => plec; set => plec = value; }// TRZA POPRAWIĆ SETTERY ?????:!!!!!!!
        public int Id { get => id; set => id = value; }
    }
}
