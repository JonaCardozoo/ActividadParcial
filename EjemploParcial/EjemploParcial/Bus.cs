using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploParcial
{
    [Serializable]
    internal class Bus:Transporte
    {

        public double PrecioFinall { get; set; }
        public int Estrellas {  get; set; }
        
        public Bus(int estrellas,int Patente):base(Patente)
        {
            Estrellas = estrellas;
        }


        public override double PrecioFinal(double precioBase)
        {
            double CobrarBus = precioBase;
            double IVA = CobrarBus * 0.115;
            PrecioFinall = CobrarBus + IVA;
            return PrecioFinall;
        }
    }
}
