using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Classi
{
    public class Persona : IEntita
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataNascita { get; set; }

        public int Eta
        {
            get
            {
                 return DateTime.Today.Year - DataNascita.Year;
            }
        }

        public  virtual string ToString()
        {
            return "Nome: " + Nome + "Cognome: " + Cognome
                + "Data di nascita: " + DataNascita.ToShortDateString()
                + "Eta: " + Eta;
        }

        private int CalcolaEta() //se non uso una proprietà uso un metodo privato
        {
            return DateTime.Today.Year - DataNascita.Year;
        }

        public string CalcolaCodiceFiscale()
        {
            return Nome.Substring(0, 3) + Cognome.Substring(0, 3) + DataNascita.Year;
        }




    }
}
