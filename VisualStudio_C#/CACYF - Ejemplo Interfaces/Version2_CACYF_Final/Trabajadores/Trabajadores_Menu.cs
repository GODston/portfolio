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
using Version2_CACYF_Final.Trabajadores;

namespace Version2_CACYF_Final.Trabajadores
{
    public partial class Trabajadores_Menu : Form
    {
        public Trabajadores_Menu()
        {
            InitializeComponent();
        }

        //Cerrar Ventana
        private void Trabajadores_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form menu = new Menu_Principal();
            menu.Show();
        }

        //Boton de Menu principal: Regresar al menu principal
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Boton agregar trabajador
        private void button1_Click(object sender, EventArgs e)
        {
            Agregar_Trabajador _Trabajador = new Agregar_Trabajador();
            _Trabajador.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Editar_Trabajador _Trabajador = new Editar_Trabajador();
            _Trabajador.Show();
        }
    }
}
