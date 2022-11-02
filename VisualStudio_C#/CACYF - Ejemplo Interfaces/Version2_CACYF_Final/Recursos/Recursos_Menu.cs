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
using Version2_CACYF_Final.Recursos;

namespace Version2_CACYF_Final.Recursos
{
    public partial class Recursos_Menu : Form
    {
        public Recursos_Menu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Recursos_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu_Principal menu_ = new Menu_Principal();
            menu_.Show();
        }

        //Boton Crear Recurso
        private void button1_Click(object sender, EventArgs e)
        {
            Crear_Recurso crear_ = new Crear_Recurso();
            crear_.Show();
        }

        //Boton Editar Recurso
        private void button2_Click(object sender, EventArgs e)
        {
            Editar_Recurso editar_ = new Editar_Recurso();
            editar_.Show();
        }

        //Boton Crear Movimiento
        private void button4_Click(object sender, EventArgs e)
        {
            Crear_Movimiento crear_ = new Crear_Movimiento();
            crear_.Show();
        }

        //Boton Crear Jaula
        private void button6_Click(object sender, EventArgs e)
        {
            Crear_Jaula crear_ = new Crear_Jaula();
            crear_.Show();
        }

        //Boton Mover Animal
        private void button5_Click(object sender, EventArgs e)
        {
            Mover_Animal mover_ = new Mover_Animal();
            mover_.Show();
        }

        private void Recursos_Menu_Load(object sender, EventArgs e)
        {
            //Oculta botones de Jaulas-radiobutton
            button6.Hide();
            button5.Hide();
            dataGridView2.Hide();

            //Oculta boton de Movimientos-radiobutton
            button4.Hide();
            dataGridView3.Hide();
        }

        //Recursos Radio Button
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Show();
            button2.Show();
            dataGridView1.Show();
            
            //Oculta botones de Jaulas-radiobutton
            button6.Hide();
            button5.Hide();
            dataGridView2.Hide();

            //Oculta boton de Movimientos-radiobutton
            button4.Hide();
            dataGridView3.Hide();
        }

        //Movimientos Radio Button
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            button4.Show();
            dataGridView3.Show();

            button1.Hide();
            button2.Hide();
            dataGridView1.Hide();

            button6.Hide();
            button5.Hide();
            dataGridView2.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            button4.Hide();
            dataGridView3.Hide();

            button1.Hide();
            button2.Hide();
            dataGridView1.Hide();

            button6.Show();
            button5.Show();
            dataGridView2.Show();
        }
    }
}
