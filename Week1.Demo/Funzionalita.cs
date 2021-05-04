using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week1.Demo.Classi;
using Week1.Demo;
using Week1.Demo.Pub_Sub;

namespace Week1.Demo
{
    class Funzionalita
    {
        public enum State
        {
            New,
            Open,
            OnHold,
            Closed
        }

        public static void EsercizioTipo()
        {
            //value type vs reference type

            //VALUE TYPE

            //booleani
            bool x = true;
            bool y = false;

            bool z = !x;

            Console.WriteLine("Valore di z: {0}", z);

            //Numerici
            int i = 0;
            i = 3; //cambio il valore direttamente alla variabile i nello stack
            int j = 34;

            //Somma: +
            //Differenza: -
            //Prodotto: +
            //Divisione: /
            //Resto: %

            int numero = 1 * (3 + 5) * 7;

            float f = 1f / 3f;
            double doubl = 1d / 3d;
            decimal dec = 1m / 3m;

            Console.WriteLine("Decimali: ");
            Console.WriteLine("f: {0}", f);
            Console.WriteLine("doubl: {0}", doubl);
            Console.WriteLine("dec: {0}", dec);

            Console.WriteLine($"Float valore massimo: {float.MaxValue}- valore minimo: {float.MinValue}");
            Console.WriteLine($"double valore massimo: {double.MaxValue}- valore minimo: {double.MinValue}");
            Console.WriteLine($"decimal valore massimo: {decimal.MaxValue}- valore minimo: {decimal.MinValue}");

            //DateTime
            DateTime now = DateTime.Now;
            DateTime today = DateTime.Today;
            DateTime data = new DateTime(2021, 05, 03);

            DateTime tomorrow = today.AddDays(1);
            DateTime post5Hours = now.AddHours(5);

            Console.WriteLine($"Tomorrow:{tomorrow}");
            Console.WriteLine($"In 5 hours: {post5Hours}");

            //Enum
            State myState = State.Open;

            if (myState == State.New) //non posso paragonarli in altro modo perchè i tipi devono essere uguali
            { Console.WriteLine("la mia variabile myState contiene New"); 
            } else
            {
                Console.WriteLine($"la mia variabile myState contiene {myState}");
            }

            //REFERENCE TYPE

            //string

            string nome = "Ilaria"; //se fosse un reference puro dovrei mettere new, ma siccome è immutabile posso non metterlo
            nome = "Giulia";

            int numeroCaratteri = nome.Length; //length è solo get, non posso modificarlo, importante per incapsulamento
            Console.WriteLine($"il nome comincia per I {nome.StartsWith("I")}");

            Console.Clear();

            //poi ci sono i reference type custom: le classi
            Persona p = new Persona
            {
                Nome = "Ilaria",
                Cognome = "Bonelli",
                DataNascita= new DateTime(1990,12,23)

            };
                
            Console.WriteLine(p.ToString()); //INCAPSULAMENTO

            Console.WriteLine(p.Eta);

            //EREDITARIETA'

            Manager m = new Manager
            {
                Nome = "Mario",
                Cognome = "Rossi",
                DataNascita = new DateTime(1984, 07, 04)

            }; //ha da subito tutte le caratteristiche di Persona

            Console.WriteLine(m.Eta);
            Console.WriteLine(m.Stipendio);

            Persona manager2 = new Manager() 
            { 
                Nome= "Luca",
                Cognome= "Verdi",
                DataNascita=new DateTime(1978,05,14)
            };

            //POLIMORFISMO

            //manager2.Stipendio non lo posso fare perchè la proprietà stipendio è solo in Manager ma questo manager2 prende solo da Persona
            Console.WriteLine(manager2.ToString()); //se invece metto virtual al tostring in persona
                                                    //e faccio l'ovverride del tostring in manager,
                                                    //posso implementare la proprità stipendio anche per manager2

            //INTERFACCE

            manager2.CalcolaCodiceFiscale();

            IEntita manager3 = new Manager();
            manager3.CalcolaCodiceFiscale();

        }

        public static int MiaSomma(int a, int b)
        {
            return a + b;
        }

        public static int ReturnZero(int a, int b)
        {
            return 0;
        }

        public static double Dividi (int a, int b)
        {
            return a / b;
        }

        public static void DemoEventi()
        {
            Publisher youtube = new Publisher("youtube.com");
            Publisher instagram = new Publisher("instagram");

            Subscriber sub1 = new Subscriber("Mario");
            Subscriber sub2 = new Subscriber("Giulia");
            Subscriber sub3 = new Subscriber("Luana");

            sub1.Subscribe(youtube);
            sub3.Subscribe(youtube);

            sub2.Subscribe(instagram);

            //scateniamo l'evento
            youtube.Publish();

            Console.WriteLine("-----------------");

            instagram.Publish();

            sub1.Unsubscribe(youtube);

            Console.WriteLine("-------------------");

            youtube.Publish();

        }



       
    }
}
