using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version2_CACYF_Final;
using Version2_CACYF_Final.Ciudadanos;
using Version2_CACYF_Final.Animal;
using Version2_CACYF_Final.Recursos;
using Version2_CACYF_Final.Citas;

namespace Version2_CACYF_Final.Menu
{
    public partial class Menu_Principal : Form
    {
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        //Boton de animales
        private void button3_Click(object sender, EventArgs e)
        {
            Animales_Menu animales = new Animales_Menu();
            animales.Show();
            this.Hide();
        }

        //Boton de trabajadores
        private void button1_Click(object sender, EventArgs e)
        {
            Version2_CACYF_Final.Trabajadores.Trabajadores_Menu trabajadores_Menu = new Trabajadores.Trabajadores_Menu();
            trabajadores_Menu.Show();
            this.Hide();
        }

        //Cerrar ventana
        private void Menu_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Boton de Ciudadanos
        private void button2_Click(object sender, EventArgs e)
        {
            Ciudadanos_Menu ciudadanos_ = new Ciudadanos_Menu();
            ciudadanos_.Show();
            this.Hide();
        }

        //Boton Recursos
        private void button4_Click(object sender, EventArgs e)
        {
            Recursos_Menu recursos_ = new Recursos_Menu();
            recursos_.Show();
            this.Hide();
        }

        //Boton de Citas
        private void button5_Click(object sender, EventArgs e)
        {
            Citas_Menu citas_ = new Citas_Menu();
            citas_.Show();
            this.Hide();
        }
    }
}
