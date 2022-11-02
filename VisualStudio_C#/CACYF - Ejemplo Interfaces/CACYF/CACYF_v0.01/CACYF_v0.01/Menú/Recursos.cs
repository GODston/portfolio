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
    public partial class Recursos : Form
    {
        public Recursos()
        {
            InitializeComponent();

            tbl_Jaulas.Hide();
            tbl_Movimientos.Hide();

            btn_Movimiento.Hide();
            btn_EliminarJaula.Hide();
            btn_MoverAnimal.Hide();
            btn_NuevaJaula.Hide();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main_Menu menu = new Main_Menu();
            menu.Show();
        }

        private void btn_NuevoR_Click(object sender, EventArgs e)
        {
            Formulario_NuevoRecurso nuevoRecurso = new Formulario_NuevoRecurso();
            nuevoRecurso.Show();

        }

        private void btn_Movimiento_Click(object sender, EventArgs e)
        {
            Formulario_Movimiento nuevoMovimiento = new Formulario_Movimiento();
            nuevoMovimiento.Show();
        }

        private void radio_Recursos_CheckedChanged(object sender, EventArgs e)
        {
            tbl_Jaulas.Hide();
            tbl_Movimientos.Hide();

            tbl_Recursos.Show();

            btn_NuevoR.Show();
            btn_Editar.Show();
            btn_EliminarRecurso.Show();
            btn_Movimiento.Hide();
            btn_EliminarJaula.Hide();
            btn_MoverAnimal.Hide();
            btn_NuevaJaula.Hide();
        }

        private void radio_Movimientos_CheckedChanged(object sender, EventArgs e)
        {
            tbl_Recursos.Hide();
            tbl_Jaulas.Hide();
            tbl_Movimientos.Show();

            btn_NuevoR.Hide();
            btn_Editar.Hide();
            btn_EliminarRecurso.Hide();
            btn_Movimiento.Show();
            btn_EliminarJaula.Hide();
            btn_MoverAnimal.Hide();
            btn_NuevaJaula.Hide();
        }

        private void radio_Jaulas_CheckedChanged(object sender, EventArgs e)
        {
            tbl_Recursos.Hide();
            tbl_Movimientos.Hide();
            tbl_Jaulas.Show();
            btn_NuevoR.Hide();
            btn_Movimiento.Hide();
            btn_Editar.Hide();

            btn_NuevoR.Hide();
            btn_Editar.Hide();
            btn_EliminarRecurso.Hide();
            btn_Movimiento.Hide();
            btn_EliminarJaula.Show();
            btn_MoverAnimal.Show();
            btn_NuevaJaula.Show();
        }

        private void btn_Editar_Click(object sender, EventArgs e)
        {
            Formulario_EditarRecurso nuevoEditar = new Formulario_EditarRecurso();
            nuevoEditar.Show();
        }

       

        private void btn_EliminarRecurso_Click(object sender, EventArgs e)
        {
            Formulario_EliminarRecurso nuevoEliminar = new Formulario_EliminarRecurso();
            nuevoEliminar.Show();
        }

        private void btn_EliminarJaula_Click(object sender, EventArgs e)
        {
            Formulario_EliminarJaula nuevoElimianrJaula = new Formulario_EliminarJaula();
            nuevoElimianrJaula.Show();
        }

        private void btn_MoverAnimal_Click(object sender, EventArgs e)
        {
            Formulario_MoverAnimal nuevoMoverAnimal = new Formulario_MoverAnimal();
            nuevoMoverAnimal.Show();
        }

        private void btn_NuevaJaula_Click(object sender, EventArgs e)
        {
            Formulario_NuevaJaula nuevoNuevaJaula = new Formulario_NuevaJaula();
            nuevoNuevaJaula.Show();
        }
        private void Recursos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
