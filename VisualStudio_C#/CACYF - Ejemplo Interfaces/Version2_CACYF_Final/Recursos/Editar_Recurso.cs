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
    public partial class Editar_Recurso : Form
    {
        public Editar_Recurso()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Recurso Actualizado Correctamente");
            this.Close();
        }
    }
}
