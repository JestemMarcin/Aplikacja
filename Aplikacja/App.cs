﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Xml;
using System.IO;

namespace Aplikacja
{

    public class App : IApp
    {

        protected List<Osoba> listao = new List<Osoba>();



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
            int id;
            if(listao.Count>0)id = listao.Last().Id + 1;
            else id = 0;
            listao.Add(new Osoba(imie, nazwisko, wiek, plec, kodpoczt, miasto, ulica, nrdomu, nrmieszkania, id));
            Console.WriteLine("Dodano nową osobe {0} {1}",imie,nazwisko);

        }
        protected void wypisz(List<Osoba> lista)
        {
            Console.WriteLine();
            if (lista.Count > 0)
            {
                Console.WriteLine($"Imie \t Nazwisko \t Wiek \t Plec \t Osoba \t Adres \t Miasto \t  Ulica \t NrDomu \t  NrDomu");
                foreach (Osoba osoba in lista)
                {
                    Console.WriteLine($"{osoba.Imie}\t{osoba.Nazwisko}\t{osoba.Wiek}\t{osoba.Plec}\t{osoba.Imie}\t{osoba.adres.Kodpoczt}\t{osoba.adres.Miasto}\t{osoba.adres.Ulica}\t{osoba.adres.Nrdomu}\t{osoba.adres.Nrmieszkania} ");
                }
            }
            else Console.WriteLine("Brak osób do wyświetlenia.");

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
            FileMode.OpenOrCreate);
            if (fs.Length == 0){ Console.WriteLine("plik jest pusty"); }
            else
            {
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(List<Osoba>));

                listao = (List<Osoba>)ser.ReadObject(reader, true);
                reader.Close();
            }
            fs.Close();
        }
        public void welcomeMessage()
        {

            Console.WriteLine("Aby zobaczyć komendy wpisz 'help', aby zakończyć aplikacje wpisz 'exit' tylko wtedy twój progress zapisze się do pliku.");
        }
        public void commandsInit()
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
                        command = command.Substring(index+1);
                        
                    }


                }
                
                switch (args[0])
                {
                    case "help":
                        Console.WriteLine("Lista Komend");
                    break;
                    case "showall":
                        wypisz(listao);
                    break;
                    case "select":
                        if (args.Count() == 3)
                            wyszukaj(args[1], args[2]);
                        else
                        Console.WriteLine("Komenda select wymaga 2 argumentów");
                        break;
                    case "exit":
                        check = false;
                    break;
                    case "default":
                        Console.WriteLine("There is no command like that");
                    break;
                    case "newperson":
                        if (args.Count() == 10)
                            dodaj(args[1], args[2], args[3], args[4], args[5], args[6], args[7], Int32.Parse(args[8]), Int32.Parse(args[9]));
                        else 
                            Console.WriteLine("Komenda new person wymaga 9 argumentów");
                    break;
                    case "delperson":
                        if (args.Count() == 2)
                            usuń(Int32.Parse(args[1]));
                        else
                        Console.WriteLine("Komenda delperson wymaga 1 argumentu");
                        break;
                    default:
                        Console.WriteLine("Nie rozpoznano komendy {0}", args[0]);
                    break;
                }
            }
        }

    }
}
