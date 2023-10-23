using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;

namespace EjemploParcial
{
    [Serializable]
    internal class Sistema
    {

        Tickets ticket;
        long cuit;
        List<Transporte> transportes = new List<Transporte>();
        List<Tickets> tickets = new List<Tickets>();
        public string Nombre {  get; set; }
        public long Cuit
        {
            get
            {
                return cuit;
            }
            set
            {
                    if(value > 9999999999 && value < 99999999999)
                    {
                        cuit = value;
                    }
                else
                {
                    throw new FormatException("CAPOEIRA,SI LLEGAS A PONER MAS DEVUELTA EL CUIT...");
                }
                
            }
        }
        public int Telefono { get; set; }
        public int NumeroTarjeta { get; set; }

        public Sistema()
        {

           
        }

        public void CrearTicket(DateTime fecha, double precioFinal, string destino, string transporte, string nombre, long cuit, int telefono, int NumeroTarjeta)
        {

            tickets.Add(new Tickets(fecha, precioFinal, destino, transporte, nombre, cuit, telefono, NumeroTarjeta));
        }

        public List<Tickets> VerListaOrdenada()
        {
             tickets.Sort();
                return tickets;
        }

        public override string ToString()
        {
            return ticket + " " +  Nombre + " " + Cuit + " " + Telefono + " " + NumeroTarjeta;
        }

    }
}
