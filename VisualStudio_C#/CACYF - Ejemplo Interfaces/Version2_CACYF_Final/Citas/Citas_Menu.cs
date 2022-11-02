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
using Version2_CACYF_Final.Citas;

namespace Version2_CACYF_Final.Citas
{
    public partial class Citas_Menu : Form
    {
        public Citas_Menu()
        {
            InitializeComponent();
        }

        private void Citas_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Citas_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu_Principal menu_ = new Menu_Principal();
            menu_.Show();
        }

        //Boton Agendar Cita
        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Cita _Cita = new Agregar_Cita();
            _Cita.Show();
        }

        //Boton cancelar cita
        private void button2_Click(object sender, EventArgs e)
        {
            Cancelar_Cita _Cita = new Cancelar_Cita();
            _Cita.Show(); 
        }
    }
}
