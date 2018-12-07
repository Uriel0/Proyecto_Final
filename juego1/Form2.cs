using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace juego1
{
    public partial class Form2 : Form
    {
        public Form2()
        {

            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //coneccion a la base de datos.
            String conexiónString = null;
            conexiónString = "Server=ALEMAN\\MSSQLSERVER01;Database=juego;Trusted_Connection=True;";
            SqlCommand comando;
            SqlConnection conexión;
            conexión = new SqlConnection(conexiónString);

            //instruccion query para insertar lo que tenga texbox.
            string query;
            query = "INSERT INTO jugadores VALUES('" + textBox1.Text + "')";

            //query = "insert into juego where puntaje = ("+lblpuntaje.text+")";

            //abre la coneccion y ejecuta el query.
            conexión.Open();
            comando = new SqlCommand(query, conexión);
            comando.ExecuteNonQuery();

           
            // cierra el formulario actual y muestra el segundo.
            this.Hide();
            Form1 cambio = new Form1();
            cambio.Show();

            //cierra la conecion de la base de datos.
            comando.Dispose();
            conexión.Close();


        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void verRegistrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 ver = new Form3();
            ver.Show();

        }
    }
}
