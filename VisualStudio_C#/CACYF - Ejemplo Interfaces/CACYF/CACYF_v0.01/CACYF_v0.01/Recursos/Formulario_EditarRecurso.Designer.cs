namespace CACYF_v0._01
{
    partial class Formulario_EditarRecurso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario_EditarRecurso));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_NombreRecurso = new System.Windows.Forms.TextBox();
            this.txt_Unidades = new System.Windows.Forms.TextBox();
            this.txt_UnidadesRecursp = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.txtbox_EditarRecurso = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(462, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "* Para conservar los datos anteriores deje el campo en blanco.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 36);
            this.label2.TabIndex = 9;
            this.label2.Text = "Seleccione Recurso a \r\nEditar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txt_NombreRecurso
            // 
            this.txt_NombreRecurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NombreRecurso.Location = new System.Drawing.Point(210, 70);
            this.txt_NombreRecurso.Name = "txt_NombreRecurso";
            this.txt_NombreRecurso.Size = new System.Drawing.Size(260, 24);
            this.txt_NombreRecurso.TabIndex = 10;
            // 
            // txt_Unidades
            // 
            this.txt_Unidades.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Unidades.Location = new System.Drawing.Point(210, 110);
            this.txt_Unidades.Name = "txt_Unidades";
            this.txt_Unidades.Size = new System.Drawing.Size(260, 24);
            this.txt_Unidades.TabIndex = 11;
            // 
            // txt_UnidadesRecursp
            // 
            this.txt_UnidadesRecursp.AutoSize = true;
            this.txt_UnidadesRecursp.BackColor = System.Drawing.Color.Transparent;
            this.txt_UnidadesRecursp.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UnidadesRecursp.ForeColor = System.Drawing.Color.White;
            this.txt_UnidadesRecursp.Location = new System.Drawing.Point(14, 113);
            this.txt_UnidadesRecursp.Name = "txt_UnidadesRecursp";
            this.txt_UnidadesRecursp.Size = new System.Drawing.Size(166, 18);
            this.txt_UnidadesRecursp.TabIndex = 12;
            this.txt_UnidadesRecursp.Text = "Unidades del Recurso";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(18, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nombre del Recurso";
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.Location = new System.Drawing.Point(300, 170);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(100, 30);
            this.btn_Editar.TabIndex = 14;
            this.btn_Editar.Text = "Editar";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Crear_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(50, 170);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.btn_Cancelar.TabIndex = 15;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // txtbox_EditarRecurso
            // 
            this.txtbox_EditarRecurso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_EditarRecurso.FormattingEnabled = true;
            this.txtbox_EditarRecurso.Location = new System.Drawing.Point(210, 30);
            this.txtbox_EditarRecurso.Name = "txtbox_EditarRecurso";
            this.txtbox_EditarRecurso.Size = new System.Drawing.Size(260, 24);
            this.txtbox_EditarRecurso.TabIndex = 16;
            // 
            // Formulario_EditarRecurso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.txtbox_EditarRecurso);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_UnidadesRecursp);
            this.Controls.Add(this.txt_Unidades);
            this.Controls.Add(this.txt_NombreRecurso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formulario_EditarRecurso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recursos - Editar Recurso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_NombreRecurso;
        private System.Windows.Forms.TextBox txt_Unidades;
        private System.Windows.Forms.Label txt_UnidadesRecursp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.ComboBox txtbox_EditarRecurso;
    }
}