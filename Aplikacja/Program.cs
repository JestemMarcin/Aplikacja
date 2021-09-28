using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplikacja
{
    class Program
    {

        static void Main(string[] args)
        {
            IApp apka = new App();
            
            apka.wczytaj();
            apka.welcomeMessage();
            apka.commandsInit();
            apka.zapisz();
            // Rzeczy które można by poprawić: właściwości w Osoba i DaneAdresowe. I pewnie wczytywanie argumentów z command lina, teraz nam ignoruje wszystkie nadmiarowe jeśli składnia na początku była poprawna.
        }
    } 
}
