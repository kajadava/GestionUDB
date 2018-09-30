using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionUDB
{
    public partial class menuprincipal : Form
    {
        public menuprincipal()
        {
            InitializeComponent();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ingresarequipo vnt0 = new ingresarequipo();
            vnt0.Show();
        }
    }
}
