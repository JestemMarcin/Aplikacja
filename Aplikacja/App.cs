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



        public App() { }

        protected void wyszukaj(string sub,string str)
        {
            List<Osoba> lista = new List<Osoba>();

            switch (sub)
            {
                case "imie":
                    lista = listao.FindAll(x => x.Imie.Contains(str));
                    break;
                case "nazwisko":
                    lista = listao.FindAll(x => x.Nazwisko.Contains(str));
                    break;
            }
            wypisz(lista);

        }
        protected void usuń(int id)
        {
            listao.Remove(new Osoba() { Id = id }) ;
            Console.WriteLine("Usunięto osobę o id {0}", id);

        }
        protected void dodaj(string imie, string nazwisko, string wiek, string plec, string kodpoczt, string miasto, string ulica, int nrdomu, int nrmieszkania)
        {
            listao.Add(new Osoba(imie, nazwisko, wiek, plec, kodpoczt, miasto, ulica, nrdomu, nrmieszkania, listao.Last().Id+1));
            Console.WriteLine("Dodano nową osobe {0} {1}",imie,nazwisko);

        }
        protected void wypisz(List<Osoba> lista)
        {
            Console.WriteLine();
            foreach (Osoba osoba in lista)
            {
                Console.WriteLine($"Imie {osoba.Imie} Nazwisko {osoba.Nazwisko} Wiek {osoba.Wiek} Plec {osoba.Plec} Osoba {osoba.Imie} Adres {osoba.Kodpoczt} Miasto {osoba.Miasto} Ulica {osoba.Ulica} NrDomu {osoba.Nrdomu}  NrDomu {osoba.Nrmieszkania} ");
            }

        }
        public void zapisz()
        {

            FileStream writer = new System.IO.FileStream("data.txt", FileMode.Create);
            DataContractSerializer ser =
                new DataContractSerializer(typeof(List<Osoba>));
            ser.WriteObject(writer, listao);
            writer.Close();
        }

        public void wczytaj()
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

        public void CommandsInit()
        {
            bool check = true;
            while (check)
            {
                string command = Console.ReadLine();
                List<string> args = new List<string>();
                bool check2 = true;
                while (check2) {
                    int index = command.IndexOf(' ');
                    if (index == -1)
                    {
                        check2 = false;
                        args.Add(command);
                    }
                    else
                    {
                        args.Add(command.Substring(0, index));
                    }


                }
                switch (args[0])
                {
                    case "help":
                        Console.WriteLine("Lista Komend");
                    break;
                    case "selectall":
                        wypisz(listao);
                    break;
                    case "select":
                        wyszukaj(args[1], args[2]);
                    break;
                    case "exit":
                        zapisz();
                        check = false;
                    break;
                    case "default":
                        Console.WriteLine("There is no command like that")
                    break;
                    case "newperson":
                    dodaj(args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9]])
                    break;
                    case "delperson":

                    break;

                }
            }
        }

    }
}
