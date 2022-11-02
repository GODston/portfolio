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
    public partial class StartUp : Form
    {
        public StartUp()
        {
            InitializeComponent();
        }
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SingIn_Click(object sender, EventArgs e)
        {
             if(Pass_1.Text=="cacyf1")
            {
                this.Hide();
                Main_Menu Menu_1 = new Main_Menu();
                Menu_1.Show();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta. Favor de intentar de nuevo.");
                Pass_1.Text = "";
                Pass_1.Focus();
            }
        }

        private void Pass_1_TextChanged(object sender, EventArgs e)
        {
            Pass_1.Focus();
        }

        private void StartUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
