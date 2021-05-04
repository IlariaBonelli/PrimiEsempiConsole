using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1.Demo.Classi
{
    public class Manager : Persona 
    {
        public double Stipendio
        {
            get
            {
                return Eta * DateTime.Today.Year;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Stipendio: " + Stipendio;
        }





    }



}
