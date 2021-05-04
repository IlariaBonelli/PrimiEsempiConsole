using System;

namespace Week1.Demo
{
    class Program
    {
        //dichiarazione delegate
        delegate int Somma(int a, int b);

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            //Funzionalita.EsercizioTipo();

            //delegate
            Somma somma = new Somma(Funzionalita.MiaSomma);
            Somma somma2 = new Somma(Funzionalita.ReturnZero);
            //Somma somma3 = new Somma(Funzionalita.Dividi); dividi non rispetta il tipo di ritorno, non posso usare il delegate e mi dà errore

            int risultato = somma(1, 2); //PASSO PER UN PUNTATORE AL METODO
            //equivalente
            int risultato3= Funzionalita.MiaSomma(1, 2); //CHIAMO DIRETTAMENTE SENZA USARE IL DELEGATE

            int risultato2 = somma2(3, 7);
            Console.WriteLine("Risultato 1 : " + risultato + " equivalente a " + risultato3);
            Console.WriteLine("Risultato 2 : " + risultato2);

            Console.Clear();
            Funzionalita.DemoEventi();


        }
    }
}
