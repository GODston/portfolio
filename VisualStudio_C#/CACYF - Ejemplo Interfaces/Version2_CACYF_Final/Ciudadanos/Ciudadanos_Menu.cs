using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version2_CACYF_Final.Menu;
using Version2_CACYF_Final.Ciudadanos;

namespace Version2_CACYF_Final.Ciudadanos
{
    public partial class Ciudadanos_Menu : Form
    {
        public Ciudadanos_Menu()
        {
            InitializeComponent();
        }

        private void Ciudadanos_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form menu = new Menu_Principal();
            menu.Show();
        }

        //Boton Menu principal
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton agregar ciudadanos
        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Ciudadano agregar_ = new Agregar_Ciudadano();
            agregar_.Show();
        }
        //Boton Eliminar Cidadano
        private void button2_Click(object sender, EventArgs e)
        {
            Eliminar_Ciudadano eliminar_ = new Eliminar_Ciudadano();
            eliminar_.Show();
        }

    }
}
