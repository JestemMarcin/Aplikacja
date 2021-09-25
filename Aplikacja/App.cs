using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace Aplikacja
{

    public class App : IApp
    {

        protected static List<Osoba> listao = new List<Osoba>();

        protected static List<Osoba> listaow = new List<Osoba>();

        public App() { }
        public void wczytaj()
        {
            /////// Wczytywanie
            ///
            string wczytaj=zplikuxD():
            listao = zpilkuxD();

        }
        public void zapisz()
        {

            doplikuxd(listao);

        }
        public void wyszukaj()
        {


        }
        public void usuń()
        {


        }
        public void dodaj()
        {


        }
        public void wypisz()
        {
            Console.WriteLine();
            foreach (Osoba osoba in listao)
            {
                Console.WriteLine($"Imie {osoba.Imie} Nazwisko {osoba.Nazwisko} Wiek {osoba.Wiek} Plec {osoba.Plec} Osoba {osoba.Imie} Adres {osoba.Kodpoczt} Miasto {osoba.Miasto} Ulica {osoba.Ulica} NrDomu {osoba.Nrdomu}  NrDomu {osoba.Nrmieszkania} ");
            }

        }
        public static void WriteObject()
        {

            FileStream writer = new System.IO.FileStream("data.txt", FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(List<Osoba>));
            ser.WriteObject(writer, listao);
            writer.Close();
        }

        public static void ReadObject()
        {
            FileStream fs = new FileStream("data.txt",
            FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
            DataContractSerializer ser = new DataContractSerializer(typeof(List<Osoba>));

            // Deserialize the data and read it from the instance.
            listao =(List<Osoba>)ser.ReadObject(reader, true);
            reader.Close();
            fs.Close();
        }

    }
}
