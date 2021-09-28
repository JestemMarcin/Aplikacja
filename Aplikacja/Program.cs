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
        }
    } 
}
