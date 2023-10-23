using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploParcial
{
    [Serializable]
    abstract class Transporte
    {


        protected int Patente {  get; set; }

        public Transporte(int Patente)
        {
            this.Patente = Patente;
        }

        public abstract double PrecioFinal(double precioBase);
    }
}
