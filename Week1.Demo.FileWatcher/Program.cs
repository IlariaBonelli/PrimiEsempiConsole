using System;
using System.IO;

namespace Week1.Demo.FileWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            FileSystemWatcher fsw = new FileSystemWatcher();

            //specifico la directory da tenere sotto controllo
            fsw.Path = @"C:\Users\ilaria.bonelli\Desktop\EsempioFileWatcher";

            //filtro che caratterizza i file da tenere sotto controllo
            fsw.Filter = "*.txt"; //con asterisco intendo tutti i file con estensione txt

            fsw.NotifyFilter= NotifyFilters.LastWrite | NotifyFilters.FileName
                | NotifyFilters.DirectoryName |NotifyFilters.LastAccess;

            //abilitare le notifiche
            fsw.EnableRaisingEvents = true;
            //multicast delegate -> alla creazione del file deve essere gestito l'evento
            fsw.Created += GestioneEvento.HandleNewTextFile;

            Console.WriteLine("Inserisci q per chiudere il programma");
            while (Console.Read() != 'q') ;


        }
    }
}
