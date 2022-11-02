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
using Version2_CACYF_Final.Animal;

namespace Version2_CACYF_Final.Animal
{
    public partial class Animales_Menu : Form
    {
        //private Animales_Menu animal;
        public Animales_Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Animales_Menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Menu_Principal menu_ = new Menu_Principal();
            menu_.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Quejas_RadioBttn(object sender, EventArgs e)
        {
            //Enseña los botones de animales
            button3.Hide();
            button2.Hide();
            //Oculta los botones de queja
            button4.Show();
            button5.Show();

            //Enseña el grid de animales
            dataGridView1.Hide();

            //Enseña el grid de quejas
            dataGridView2.Show();
        }

        //Evento que inicializa los componentes
        private void Iniciar_AnimMenu(object sender, EventArgs e)
        {
            button4.Hide();
            button5.Hide();
            dataGridView2.Hide();   
        }

        private void Animal_Check(object sender, EventArgs e)
        {
            //Enseña los botones de animales
            button3.Show();
            button2.Show();
            //Oculta los botones de queja
            button4.Hide();
            button5.Hide();

            //Enseña el grid de animales
            dataGridView1.Show();

            //Enseña el grid de quejas
            dataGridView2.Hide();
        }

        //Boton Actualizar Queja
        private void button4_Click(object sender, EventArgs e)
        {
            Actualizar_Queja _Queja = new Actualizar_Queja();
            _Queja.Show();
        }

        //Boton Agregar Queja
        private void button5_Click(object sender, EventArgs e)
        {
            Agregar_Queja _Queja = new Agregar_Queja();
            _Queja.Show();
        }

        //Boton Salida Animal
        private void button3_Click(object sender, EventArgs e)
        {
            Salida_Animal salida = new Salida_Animal();
            salida.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar_Animal agregar = new Agregar_Animal();
            agregar.Show();
        }
    }
}
