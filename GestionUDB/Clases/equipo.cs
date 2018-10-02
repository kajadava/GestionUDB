using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace GestionUDB.Clases
{
    class equipo
    {
        public int idequipo { get; set; }
        public String nombreequipo { get; set; }
        public String marca { get; set; }
        public String modelo { get; set; }
        public String noserie { get; set; }
        public String noinventario { get; set; }
        public String area { get; set; }

        public equipo()
        {
        }

        public equipo(int ideq, String nomequ, String mar, String mod,String noser, String noinv, String are)
        {
            this.idequipo = ideq;
            this.nombreequipo = nomequ;
            this.marca = mar;
            this.modelo = mod;
            this.noserie = noser;
            this.noinventario = noinv;
            this.area = are;
        }

        public equipo(String nomequ, String mar, String mod, String noser, String noinv, String are)
        {

            this.nombreequipo = nomequ;
            this.marca = mar;
            this.modelo = mod;
            this.noserie = noser;
            this.noinventario = noinv;
            this.area = are;
        }

        public static void insertarEquipo(MySqlConnection conexion, equipo equipo)
        {
            String query = "INSERT INTO Equipo(nombreequipo, marca, modelo, noserie, numinventario, area) VALUES('" + equipo.nombreequipo +"','" + equipo.marca +"','" + equipo.modelo +"','" + equipo.noserie +"','" + equipo.noinventario +"','" + equipo.area +"')";
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexion);
                Int32 lector = (Int32)comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            { throw ex; }



        }
        public static void listarequipo(MySqlConnection conexion, DataGridView dgv)
        {
            DataTable datat = new DataTable();
            try
            {
                MySqlCommand comando = new MySqlCommand(string.Format(("select * from equipo")), conexion);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(comando);
                dataAdapter.Fill(datat);
                dgv.DataSource = datat;
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
