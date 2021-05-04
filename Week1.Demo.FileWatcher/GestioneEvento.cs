using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.FileWatcher
{
    public class GestioneEvento
    {
        public static void HandleNewTextFile(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"Un nuovo file è stato creato {e.Name}");

            //Lettura da file
            using StreamReader reader = File.OpenText(e.FullPath);
            Console.WriteLine($"--- lettura di {e.Name} ---");
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
            //chiusura del flusso di lettura
            reader.Close();

            Console.WriteLine("Fine del contenuto");

            //Scrittura su file

            using StreamWriter writer = File.CreateText(@"C:\Users\ilaria.bonelli\Desktop\EsempioFileWatcher\ProvaScrittura.txt");
            writer.WriteLine($"Scrivo nuove informazioni su file");
            //chiusura del flusso di scrittura
            writer.Close();

        }
    }
}
