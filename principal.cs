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
    public partial class principal : Form
    {
        public principal()
        {
            InitializeComponent();
        }



        private void button14_Click(object sender, EventArgs e)
        {
            OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data Source=titi.accdb");
            conexion.Open();

            string acc = "SELECT * FROM Tortas WHERE Nombre = '" + txtbuscador.Text + "' ;";

            OleDbCommand comando = new OleDbCommand(acc, conexion);
            OleDbDataReader reader;
            reader = comando.ExecuteReader();

            bool ExisteTorta = reader.HasRows;
            if (ExisteTorta)
            {
                while (reader.Read())
                {
                    string nombre = reader["Nombre"].ToString();
                    string ingredientes = reader["Ingredientes"].ToString();
                    string preparacion = reader["Preparacion"].ToString();
                    string tiempo = reader["Tiempo"].ToString();
                    string dificultad = reader["Dificultad"].ToString();
                    string porciones = reader["Porciones"].ToString();
                    Recetastortas mm = new Recetastortas(nombre, ingredientes, preparacion, tiempo, dificultad, porciones);
                    mm.Show();
                }
               
            }
            else
            {
                MessageBox.Show("No se encontro ");

                return;
            }
            conexion.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form3 ini = new Form3();
            ini.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            brownieboton mm = new brownieboton();
            mm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chocotortaboton mm = new chocotortaboton();
            mm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Carrotcakeboton mm = new Carrotcakeboton();
            mm.Show();
        }
    }
}
