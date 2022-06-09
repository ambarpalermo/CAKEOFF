using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            //cuando se apreta el botón se carga la imagen
            loadImage();
        }
        
        async Task loadImage()
        {
            //aca determino cuales son los archivos de imagen que se van a poder usar
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "¨C:\\";
            dialog.Filter = "Archivos de Imagen (*.jpg) (*.jpeg)|*.jpg; *.jpeg| PNG  (*.png) | *.png|GIF (*.gif) | *.gif";

            //aca se esta seleccionando y analizando la imagen
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string imagen = dialog.FileName;
                image1.ImageLocation = imagen;
                txtimagen.Text = imagen;
                hola(imagen);
                LoadingGIF.Visible = false;
                await analizeImage(imagen);
            }
            else
            {
                MessageBox.Show("No se selecciono ninguna imagen");
            }
        }

        private async void hola(string imagen)
        {
            await analizeImage(imagen);
        }

        //aca se termina de analizar la imagen y se muestra en el text box el nombre de la torta que coincide con la imagen
        async Task analizeImage(String path)
        {

            JArray resultado = await predict(path);
            label1.Text = resultado[0]["class"].ToString();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            LoadingGIF.Visible = false;
        }

        async Task<JArray> predict(string imagePath)
        {
            //esto es para poder conectar teachablemachine con visual
            string url = "https://teachablemachine.withgoogle.com/models/cXuApEf5-/";


            var proc = new System.Diagnostics.Process();
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.FileName = "powershell.exe";
            proc.StartInfo.Arguments = "./teachablemachine-win.exe " + url + " " + imagePath;
            proc.Start();
            string result = proc.StandardOutput.ReadLine();
            proc.WaitForExit();
            //MessageBox.Show(result);
            JArray jsonArray = JArray.Parse(result);
            return jsonArray;
        }   
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            LoadingGIF.Visible = true;
            loadImage();

        }

        private void LoadingGIF_Click(object sender, EventArgs e)
        {

        }
    }
}
