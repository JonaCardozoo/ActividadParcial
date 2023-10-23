using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploParcial
{
    [Serializable]
    internal class Avion:Transporte
    {
        
        public double PrecioFinall { get; set; }
        
        public Avion(int Patente):base(Patente)
        {

        }
        public override double PrecioFinal(double precioBase)
        {

            double CobrarAvion = precioBase;
            double impuesto = CobrarAvion * 0.30;
            double IVA = CobrarAvion * 0.21;
            PrecioFinall = CobrarAvion + impuesto + IVA;
            return PrecioFinall;
            
        }
    }
}
