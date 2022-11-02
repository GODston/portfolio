using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version2_CACYF_Final.Recursos
{
    public partial class Crear_Movimiento : Form
    {
        public Crear_Movimiento()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Movimiento Creado Correctamente");
            this.Close();
        }
    }
}
