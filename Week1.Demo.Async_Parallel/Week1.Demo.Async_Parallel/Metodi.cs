using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Week1.Demo.Async_Parallel
{
    public class Metodi
    {
        public static void ForNormale()
        {
            for(int i=0; i<10; i++)
            {
                Console.WriteLine("Start " + i);
                //aggiungo una chiamata che introduce un elemento di ritardo
                Task.Delay(10).Wait();
                Console.WriteLine("End " + i);
            }
        }
        public static void ForParallelo()
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine("Start parallel: " + i);
                Task.Delay(10).Wait();

                Console.WriteLine("End parallel: " + i);
            });
        }

        //VERSIONE SINCRONA
        public static void MetodoA()
        {
            Console.WriteLine("Inizio metodo A");

            Thread.Sleep(3000);//millisecondi come argomento

            Console.WriteLine("Fine metodo A");
        }

        //VERSIONE ASINCRONA
        public static async Task MetodoAAsync()
        {
            Console.WriteLine("Inizio metodo async A");
            await Task.Delay(3000);
            Console.WriteLine("Fine metodo async A");
        }

        //VERSIONE SINCRONA
        public static void MetodoB()
        {
            Console.WriteLine("Inizio metodo B");

            Thread.Sleep(3000);//millisecondi come argomento

            Console.WriteLine("Fine metodo B");
        }

        //VERSIONE ASINCRONA
        public static async Task MetodoBAsync()
        {
            Console.WriteLine("Inizio metodo async B");
            await Task.Delay(3000);
            Console.WriteLine("Fine metodo async B");
        }

        //VERSIONE SINCRONA
        public static void MetodoC()
        {
            Console.WriteLine("Inizio metodo C");

            Thread.Sleep(3000);//millisecondi come argomento

            Console.WriteLine("Fine metodo C");
        }

        //VERSIONE ASINCRONA
        public static async Task MetodoCAsync()
        {
            Console.WriteLine("Inizio metodo async C");
            await Task.Delay(3000);
            Console.WriteLine("Fine metodo async C");
        }


    }
}
