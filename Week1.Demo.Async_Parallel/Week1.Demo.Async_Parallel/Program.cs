using System;
using System.Threading.Tasks;

namespace Week1.Demo.Async_Parallel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------For Normale -------");
            Metodi.ForNormale();
            Console.WriteLine("--------");
            Console.WriteLine("-------For Parallelo -------");
            Metodi.ForParallelo();
            Console.WriteLine("--------");

            //metodi sincroni - esecuzione sequenziale
            Metodi.MetodoA();
            Metodi.MetodoB();
            Metodi.MetodoC();

            //metodi asincroni - esecuzione parallela (contemporanea, non sequenziale)

            Task taskA = Metodi.MetodoAAsync();
            Task taskB = Metodi.MetodoBAsync();
            Task taskC = Metodi.MetodoCAsync();

            Console.ReadKey();


        }
    }
}
