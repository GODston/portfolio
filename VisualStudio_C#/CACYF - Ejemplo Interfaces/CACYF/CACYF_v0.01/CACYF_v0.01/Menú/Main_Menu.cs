using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CACYF_v0._01
{
    public partial class Main_Menu : Form
    {
        public Main_Menu()
        {
            InitializeComponent();
        }

        private void Main_Menu_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartUp startUp = new StartUp();
            startUp.Show();
        }

        private void btn_Animales_Click(object sender, EventArgs e)
        {
            this.Hide();
            Animales animales = new Animales();
            animales.Show();
        }

        private void btn_Recursos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Recursos recursos = new Recursos();
            recursos.Show();
        }

        private void btn_Citas_Click(object sender, EventArgs e)
        {
            this.Hide();
            Citas citas = new Citas();
            citas.Show();
        }

        private void btn_Trabajadores_Click(object sender, EventArgs e)
        {
            this.Hide();
            Trabajadores trabajadores = new Trabajadores();
            trabajadores.Show();
        }

        private void btn_Ciudadanos_Click(object sender, EventArgs e)
        {
            this.Hide();
            Ciudadanos ciudadanos = new Ciudadanos();
            ciudadanos.Show();
        }

        private void Main_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
