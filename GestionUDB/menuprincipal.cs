using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GestionUDB
{
    public partial class menuprincipal : Form
    {
        Conexion con = new Conexion();
        public menuprincipal()
        {
            InitializeComponent();
        }
        private void menuprincipal_Load(object sender, EventArgs e)
        {
            try
            {
                if (con.conectar() == true)
                {
                    listarequipo(con.conexion);
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
            con.desconectar();
        }
        public void listarequipo(MySqlConnection conect)
        {
            Clases.equipo.listarequipo(conect, dataGridView1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ingresarequipo vnt0 = new ingresarequipo();
            vnt0.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.conectar();
            MySqlCommand cmd = con.conexion.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from equipo where nombreequipo like('" + textBox1.Text + "%') or noserie like('" + textBox1.Text + "%') or numinventario like('" + textBox1.Text + "%')";
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

            con.desconectar();
        }

    }
}
