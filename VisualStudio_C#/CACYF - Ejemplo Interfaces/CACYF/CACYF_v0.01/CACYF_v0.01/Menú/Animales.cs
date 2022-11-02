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
    public partial class Animales : Form
    {
        public Animales()
        {
            InitializeComponent();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu menu = new Main_Menu();
            menu.Show();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
