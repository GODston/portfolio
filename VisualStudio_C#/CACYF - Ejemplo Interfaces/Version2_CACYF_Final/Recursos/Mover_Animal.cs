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
    public partial class Mover_Animal : Form
    {
        public Mover_Animal()
        {
            InitializeComponent();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Mover_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Animal Movido Correctamente");
            this.Close();
        }
    }
}
