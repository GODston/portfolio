using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version2_CACYF_Final.Trabajadores
{
    public partial class Editar_Trabajador : Form
    {
        public Editar_Trabajador()
        {
            InitializeComponent();
        }

        //Boton Actualizar
        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos de Trabajador Actualizados");
            this.Close();
        }

        //Boton Cancelar
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
