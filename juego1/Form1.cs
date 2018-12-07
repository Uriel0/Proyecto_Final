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
    public partial class Form1 : Form

    {

        private SqlDataReader dataReader;

        int contadormovimientos = 1;
        bool volararriba = false;
        int distancia = 0;
        Random posicionramdom = new Random();


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            //tomar el tiempo de este timer para agregarlo a la base de datos.
            timer4.Start();

        }
        public void iniciarjuego()
        {
            player.Location = new Point(19, 255);
            distancia = posicionramdom.Next(-160, 118);
            tuboarriba.Location = new Point(270, -173 - distancia);
            tuboabajo.Location = new Point(270, 319 - distancia);
            puntaje.Text = "0";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int cantidadmovimientos = 3;
            if(contadormovimientos <= cantidadmovimientos)
            {
                player.Image = Properties.Resources.Red__Angry_Birds_;
                contadormovimientos++;

            }
            if ((contadormovimientos > cantidadmovimientos / 1) && (contadormovimientos <= cantidadmovimientos * 1))
            {

                player.Image = Properties.Resources.Red__Angry_Birds_;
                contadormovimientos++;
            }
            contadormovimientos = (contadormovimientos > cantidadmovimientos * 1) ? 0 : contadormovimientos;

            int ly = player.Location.Y;
            int lx = player.Location.X;

            if (volararriba)
            {
                ly = ly - 10;
                volararriba = false;
            }
            else
            {
                ly++;
            }
            player.Location = new Point(player.Location.X, ly);
            if ((player.Bounds.IntersectsWith(barrera.Bounds))||(player.Bounds.IntersectsWith(tuboarriba.Bounds))||(player.Bounds.IntersectsWith(tuboabajo.Bounds)))
            {
                iniciarjuego();
            }
            puntaje.Location = new Point(player.Location.X + 20, player.Location.Y - 15);
            puntaje.Text = (tuboarriba.Location.X == player.Location.X) ? Convert.ToString((Convert.ToInt32(puntaje.Text) + 1)).ToString() : puntaje.Text;
            

        }

        private void tuboarriba_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Space))
            {
                volararriba = true;

            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (tuboabajo.Location.X>-100)
            {
                tuboabajo.Location = new Point((tuboabajo.Location.X) - 1, tuboabajo.Location.Y);
                tuboarriba.Location = new Point((tuboarriba.Location.X) - 1, tuboarriba.Location.Y);    
            }
            else
            {
                distancia = posicionramdom.Next(-120, 118);
                tuboabajo.Location = new Point(200,119 + distancia);
                tuboarriba.Location = new Point(200,173 + distancia);

            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            barrera.Location = (barrera.Location.X > -100) ? new Point((barrera.Location.X) - 1, barrera.Location.Y) : barrera.Location = new Point(-5, barrera.Location.Y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            String conexiónString = null;
            conexiónString = "Server=ALEMAN\\MSSQLSERVER01;Database=juego;Trusted_Connection=True;";
            SqlConnection conexión;
            conexión = new SqlConnection(conexiónString);

            SqlCommand comando;
            string query;

            query = "select * from jugadores";


            try
            {
                conexión.Open();
                comando = new SqlCommand(query, conexión);
                dataReader = comando.ExecuteReader();
                

                if (dataReader.Read() == true)
                {
                    label1.Text = dataReader["gamer"].ToString();
                    

                }
                else
                {
                    label1.Text = "Sin usuario";
                }
                comando.Dispose();
                conexión.Close();

            }
            catch (Exception ex)


            {
                MessageBox.Show(ex.ToString());

            }

        }
    }
}
