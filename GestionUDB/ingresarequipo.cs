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
    public partial class ingresarequipo : Form
    {
        Conexion con = new Conexion();

        public ingresarequipo()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ingresarequipo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            menuprincipal vnt0 = new menuprincipal();
            vnt0.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                Clases.equipo equipo  = new Clases.equipo(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text);
                try
                {
                    if (con.conectar())
                    {
                        Clases.equipo.insertarEquipo(con.conexion, equipo);
                        MessageBox.Show("Equipo registrado exitosamente");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";
                        textBox6.Text = "";
                        
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("error es probable que el número de inventario ya esté registrado");
                }

                con.desconectar();
            
        }
    }
}
