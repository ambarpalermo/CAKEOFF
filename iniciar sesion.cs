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
    public partial class iniciar_sesion : Form
    {
        DataSet ds = new DataSet();

        public iniciar_sesion()
        {
            InitializeComponent();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            registrarse ini = new registrarse();
            ini.Show();
        }

        private void btniniciosesion_Click(object sender, EventArgs e)
        {
            OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data Source=titi.accdb");
            conexion.Open();

            string acc = "SELECT * FROM Usuarios WHERE Usuario = '" +txtNombre.Text+ "' AND [Password] = '" +txtContra.Text+ "' ;";
            // MessageBox.Show(acc);
            OleDbCommand comando = new OleDbCommand(acc, conexion);


            OleDbDataReader reader;

            reader = comando.ExecuteReader();

            //MessageBox.Show(Convert.ToString(reader.HasRows));

            bool ExisteUsuario = reader.HasRows;
            if (ExisteUsuario)
            {
                principal ini = new principal();
                ini.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("El Usuario no existe");
                return;
            }
              
            
            /*
            OleDbDataAdapter da = new OleDbDataAdapter(comando);
            da.Fill(ds, "Usuarios");

            if(ds.Tables["Usuarios"].Rows.Count == 0)
            {
                MessageBox.Show("Usuario no encontrado");
            }
            else
            {
                MessageBox.Show("Bienvenido");

                principal ini = new principal();
                ini.Show();
            }
            */
            conexion.Close();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtContra_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
