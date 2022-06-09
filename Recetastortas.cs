using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Recetastortas : Form
    {
        string nombre, ingredientes, preparacion, tiempo, dificultad, porciones;

        public Recetastortas(string nom, string ing, string prepara, string tie, string difi, string porc)
        {
            this.nombre = nom;
            this.ingredientes = ing;
            this.preparacion = prepara;
            this.tiempo = tie;
            this.dificultad = difi;
            this.porciones = porc;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Recetastortas_Load(object sender, EventArgs e)
        {
            lblnombre.Text = this.nombre;
            lblingredientes.Text = this.ingredientes;
            lblpreparacion.Text = this.preparacion;
            lbltiempo2.Text = this.tiempo;
            lbldificultad2.Text = this.dificultad;
            lblporciones2.Text = this.porciones;
        }
    }
}
