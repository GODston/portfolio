﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CACYF_v0._01
{
    public partial class Formulario_MoverAnimal : Form
    {
        public Formulario_MoverAnimal()
        {
            InitializeComponent();
        }

        private void btn_Mover_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
