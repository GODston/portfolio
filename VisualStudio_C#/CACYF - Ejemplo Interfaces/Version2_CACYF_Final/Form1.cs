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

namespace Version2_CACYF_Final
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_Principal menu_Principal = new Menu_Principal();
            menu_Principal.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
