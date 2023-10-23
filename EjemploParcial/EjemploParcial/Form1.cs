using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;

namespace EjemploParcial
{
    public partial class Form1 : Form
    {
        Sistema sistema;
        Tickets tickets;
        Fresumen resumen = new Fresumen();  
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            Transporte transporte = null;

            if (cbTransporte.SelectedItem.ToString() == "Avion")
            {
                transporte = new Avion(23242);
            }

            else if (cbTransporte.SelectedItem.ToString() == "Bus")
            {
                transporte = new Bus(3,34535);
            }

            else
            {
                MessageBox.Show("CAPOOOOOOOOOOOOOOOOOO,SELECCIONA","ERRORRR", MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
                return;
            }

            DateTime Fecha = DateTime.Now;
            string destino = cbTransporte.SelectedItem.ToString();
            double precio = transporte.PrecioFinal(Convert.ToInt32(textBox1.Text));
            string transportee = cbDestino.SelectedItem.ToString();
           
            long cuit = Convert.ToInt64(textBox2.Text);
            string nombre = textBox3.Text;
            int telefono = Convert.ToInt32(textBox4.Text);
            int NumeroTarjeta = Convert.ToInt32(textBox5.Text);

            try
            {
                
                sistema.CrearTicket(Fecha, precio, destino, transportee,nombre, cuit, telefono, NumeroTarjeta);

            }
            catch (FormatException ex)
            {

                MessageBox.Show(ex.Message);
                return;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string rutaCarpeta = Application.StartupPath;
            string rutaArchivo = Path.Combine(rutaCarpeta, "destinos.data");

            FileStream archivo = null;

            try
            {
                if (File.Exists(rutaArchivo))
                {
                    archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);
                    BinaryFormatter bt = new BinaryFormatter();
                    sistema = bt.Deserialize(archivo) as Sistema;
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if (archivo != null)
                {
                    archivo.Close();
                }

            }

            if(sistema == null)
            {
                sistema = new Sistema();
            }

            cbTransporte.Items.Add("Avion");
            cbTransporte.Items.Add("Bus");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            resumen.listBox1.Items.Clear();
            foreach (Tickets tickets in sistema.VerListaOrdenada())
            {
                resumen.listBox1.Items.Add(tickets);
                resumen.listBox1.Items.Add("----------------------------------------------------------------------------------------------------");
            }

            resumen.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "SELECCIONA ALGO CAPO";
            open.Filter = "archivo|*.txt";

            if(open.ShowDialog() == DialogResult.OK)
            {
                FileStream file = new FileStream(open.FileName,FileMode.Open,FileAccess.Read);
                StreamReader s = new StreamReader(file);
                
                while (!s.EndOfStream)
                {
                    resumen.listBox1.Items.Add(s.ReadLine());
                }

                s.Close();
                file.Close();

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            string rutaCarpeta = Application.StartupPath;
            string rutaArchivo = Path.Combine(rutaCarpeta,"destinos.data");
            FileStream archivo = null;

            try
            {
                archivo = new FileStream(rutaArchivo, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter BF = new BinaryFormatter();
                BF.Serialize(archivo,sistema);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                if(archivo != null)
                
                {
                    archivo.Close();
                }
                
            }

        }

        private void label1_VisibleChanged(object sender, EventArgs e)
        {

        }
    }
}
