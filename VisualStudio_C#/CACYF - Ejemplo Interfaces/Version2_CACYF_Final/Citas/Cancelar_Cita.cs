using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Version2_CACYF_Final.Citas
{
    public partial class Cancelar_Cita : Form
    {
        public Cancelar_Cita()
        {
            InitializeComponent();
        }

        //Boton Elimanr
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cita Eliminada Correctamente");
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
