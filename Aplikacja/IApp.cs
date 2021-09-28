namespace Aplikacja
{
    public interface IApp
    {
        void wczytaj();
        // Wczytuje progress z pliku

        void commandsInit();
        // Rozpoczyna wczytywanie komend z konsoli

        void welcomeMessage();
        // Wyświetla wiadomość powitalną

        void zapisz();
        // Zapisuje progress do pliku
    }
}