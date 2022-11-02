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
    public partial class Crear_Jaula : Form
    {
        public Crear_Jaula()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Crear_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jaula Creada Correctamente");
            this.Close();
        }
    }
}
