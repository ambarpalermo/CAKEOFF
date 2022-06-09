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
    public partial class registrarse : Form
    {
        public registrarse()
        {
            InitializeComponent();
        }

        private void btnregistrar_Click(object sender, EventArgs e)
        {
            OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;data Source=titi.accdb");
            conexion.Open();

            string acc = "INSERT INTO Usuarios (Usuario, [Password], Email) VALUES ('" +txtusuario.Text+ "', '" +txtcontra.Text+ "', '" +txtemail.Text+ "')";
            OleDbCommand comando = new OleDbCommand(acc, conexion);
            
            comando.ExecuteNonQuery();

            conexion.Close();

            this.Close();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
