using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version2_CACYF_Final.Ciudadanos
{
    public partial class Agregar_Ciudadano : Form
    {
        public Agregar_Ciudadano()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ciudadano Agregado Correctamente");
            this.Close();
        }
    }
}
