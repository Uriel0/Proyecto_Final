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
    public partial class Form3 : Form
    {
        private SqlDataReader dataReader;
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //coneccion a la base de datos.
            String conexiónString = null;
            conexiónString = "Server=ALEMAN\\MSSQLSERVER01;Database=juego;Trusted_Connection=True;";
            
            SqlConnection conexión;
            conexión = new SqlConnection(conexiónString);

          
            string query;

            query = "select * from jugadores";


        }
    }
}
