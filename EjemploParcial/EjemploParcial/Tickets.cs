using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace EjemploParcial
{
    [Serializable]
    internal class Tickets:IComparable
    {
        public DateTime Fecha {  get; set; }
        public double PrecioFinal { get; set; }
        public int CantidadDeViajes { get; set; }
        public string Destino { get; set; }
        public string Transporte { get; set; }

        public Tickets(DateTime fecha,double precioFinal,string destino,string transporte, string nombre, long cuit, int telefono, int NumeroTarjeta) 
        {
            Fecha = fecha;
            PrecioFinal = precioFinal;
            Destino = destino;
            Transporte = transporte;
            CantidadDeViajes++;
        }

        public int CompareTo(object obj)
        {
            Transporte transporte = obj as Transporte;
            int posicion = -1;
            if (transporte != null)
            {
                posicion = Destino.CompareTo(Destino);
            }
            return posicion;
        }

        public override string ToString()
        {
            return Fecha.ToString() + " " + PrecioFinal.ToString() + " " + Destino + " " + Transporte;
        }

    }
}
