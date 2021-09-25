using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    public class DaneAdresowe
    {
        private string ulica;
        private int nrmieszkania;
        private string kodpoczt;
        private string miasto;
        private int nrdomu;

        public DaneAdresowe(string kodpoczt, string miasto, string ulica, int nrdomu, int nrmieszkania)
        {
            this.Kodpoczt = kodpoczt;
            this.Miasto = miasto;
            this.Ulica = ulica;
            this.Nrdomu = nrdomu;
            this.Nrmieszkania = nrmieszkania;
        }

        public string Kodpoczt { get => kodpoczt; set => kodpoczt = value; }
        public string Miasto { get => miasto; set => miasto = value; }
        public string Ulica { get => ulica; set => ulica = value; }
        public int Nrdomu { get => nrdomu; set => nrdomu = value; }
        public int Nrmieszkania { get => nrmieszkania; set => nrmieszkania = value; } // TRZA POPRAWIĆ SETTERY ?????:!!!!!!!
    }
}
