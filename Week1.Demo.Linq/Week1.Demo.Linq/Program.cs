using System;
using System.Collections.Generic;
using System.Linq;

namespace Week1.Demo.Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Valutazione> voti = Program.CaricaValutazioni();
            // recupero tutti i voti di Francesca
            // lambda expression
            var votiFrancesca = voti.Where(votazione => votazione.NomeStudente.Equals("Francesca"));
            //query syntax o fluent api
            var votiFrancescaFluentApi =
                from valutazione in voti
                where valutazione.NomeStudente.Equals("Francesca")
                select valutazione;

            foreach (Valutazione valutazione in votiFrancesca)
            {
                Console.WriteLine($"Nome: {valutazione.NomeStudente})" +
                    $"Data: {valutazione.DataValutazione.ToShortDateString()}" +
                    $"Voto: {valutazione.Voto}" +
                    $"Materia: {valutazione.Materia}");
            }

            Console.WriteLine("-------------");
            foreach (Valutazione valutazione in votiFrancescaFluentApi)
            {
                Console.WriteLine($"Nome: {valutazione.NomeStudente})" +
                    $"Data: {valutazione.DataValutazione.ToShortDateString()}" +
                    $"Voto: {valutazione.Voto}" +
                    $"Materia: {valutazione.Materia}");
            }

            //voti matematica ordinati per data valutazione
            //lambda expression
            var votiMatematicaOridnati = voti
                                         .Where(v => v.Materia == Materia.Matematica)
                                         .OrderBy(v => v.DataValutazione);
                                         //.ThenBy(v=> v.Voto)

            //equivalente a
            var votiMatematicaOrdinatiFA =
                from voto in voti
                where voto.Materia == Materia.Matematica
                orderby voto.DataValutazione
                select voto;
            foreach (Valutazione valutazione in votiMatematicaOridnati)
            {
                Console.WriteLine(valutazione.NomeStudente + " " 
                    + valutazione.DataValutazione.ToShortDateString() + " " 
                    + valutazione.Materia);
            }

            foreach (var val in votiMatematicaOrdinatiFA)
            {
                Console.WriteLine(val.NomeStudente + " "
                    + val.DataValutazione.ToShortDateString() + " "
                    + val.Materia); 
            }


            var soloVoti = voti.Where(v => v.NomeStudente.Equals("Mario"))
                            .Select(v => new { v.Voto }); //ANONYMOUS TYPE

            //equivalente a fluent api
            var soloVotiFA =
                from voto in voti
                where voto.NomeStudente.Equals("Mario")
                select new { voto.Voto };


            foreach(var voto in soloVoti)
            {
                Console.WriteLine(voto.Voto);
                Console.WriteLine($"Stampa dei voti di Mario");
            }

            foreach (var voto in soloVotiFA)
            {
                Console.WriteLine(voto.Voto);
                Console.WriteLine($"Stampa dei voti di Mario ottenuti con Fluent Api");
            }

            //Media voti per ogni studente
            //lambda expression
            var mediaVotiStudente = voti
                                     .GroupBy(v => v.NomeStudente, //proprietà su cui raggruppare
                                     (key, grp) => new { Nome= key, //caratteristiche del gruppo (un tipo anonimo che vado a restituire)
                                      Media= grp.Average(v => v.Voto),
                                      Max = grp.Max(v => v.Voto),
                                      Min = grp.Min(v => v.Voto)
                                    });
            //EQUIVALENTE A

            var mediaMaxMinStudenteFA =
                from voto in voti
                group voto by voto.NomeStudente into grp
                select new
                {
                    Nome = grp.Key,
                    Media = grp.Average(v => v.Voto),
                    Max = grp.Max(v => v.Voto),
                    Min = grp.Min(v => v.Voto)
                };

            Console.WriteLine("Stampa media, massimo, minimo dei voti per ogni studente");
            foreach(var gruppo in mediaVotiStudente)
            {
                Console.WriteLine($"Nome: {gruppo.Nome} - " + $"Media voti: {gruppo.Media} " +
                    $"- Voto massimo: {gruppo.Max} " + $"- Voto minimo: {gruppo.Min}");
            }

            Console.WriteLine("----------");

            foreach (var gruppo in mediaMaxMinStudenteFA)
            {
                Console.WriteLine($"Nome: {gruppo.Nome} - " + $"Media voti: {gruppo.Media} " +
                    $"- Voto massimo: {gruppo.Max} " + $"- Voto minimo: {gruppo.Min}");
            }



        }

        public static List<Valutazione> CaricaValutazioni()
        {
            List<Valutazione> valutazioni = new List<Valutazione>()
            {
                new Valutazione
                {   NomeStudente = "Mario",
                    DataValutazione = new DateTime(2021,05,05),
                    Voto = 7, 
                    Materia=Materia.Geografia
                },

                new Valutazione
                {
                    NomeStudente="Mario",
                    DataValutazione= new DateTime(2021,04,27),
                    Voto= 3,
                    Materia= Materia.Matematica
                },

                new Valutazione
                {
                    NomeStudente= "Tiziana",
                    DataValutazione= new DateTime(2021,04,27),
                    Voto= 8,
                    Materia= Materia.Italiano
                },
                new Valutazione
                {
                    NomeStudente= "Francesca",
                    DataValutazione= new DateTime(2021,04,12),
                    Voto= 5,
                    Materia= Materia.Storia
                },
                new Valutazione
                {
                    NomeStudente= "Francesca",
                    DataValutazione= new DateTime(2021,05,2),
                    Voto= 9,
                    Materia= Materia.Matematica
                },

            };

            return valutazioni;
        }
    }
}
