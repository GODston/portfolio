namespace CACYF_v0._01
{
    partial class Recursos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recursos));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Back = new System.Windows.Forms.Button();
            this.tbl_Recursos = new System.Windows.Forms.DataGridView();
            this.btn_NuevoR = new System.Windows.Forms.Button();
            this.btn_Movimiento = new System.Windows.Forms.Button();
            this.btn_Editar = new System.Windows.Forms.Button();
            this.radio_Recursos = new System.Windows.Forms.RadioButton();
            this.radio_Movimientos = new System.Windows.Forms.RadioButton();
            this.radio_Jaulas = new System.Windows.Forms.RadioButton();
            this.tbl_Movimientos = new System.Windows.Forms.DataGridView();
            this.tbl_Jaulas = new System.Windows.Forms.DataGridView();
            this.btn_NuevaJaula = new System.Windows.Forms.Button();
            this.btn_EliminarJaula = new System.Windows.Forms.Button();
            this.btn_MoverAnimal = new System.Windows.Forms.Button();
            this.btn_EliminarRecurso = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Recursos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Movimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Jaulas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Impact", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(80, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 45);
            this.label2.TabIndex = 9;
            this.label2.Text = "CACYF";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(290, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 10;
            this.label1.Text = "Recursos";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(997, 574);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 25);
            this.btn_Back.TabIndex = 11;
            this.btn_Back.Text = "Volver";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // tbl_Recursos
            // 
            this.tbl_Recursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Recursos.Location = new System.Drawing.Point(300, 120);
            this.tbl_Recursos.Name = "tbl_Recursos";
            this.tbl_Recursos.Size = new System.Drawing.Size(770, 440);
            this.tbl_Recursos.TabIndex = 12;
            // 
            // btn_NuevoR
            // 
            this.btn_NuevoR.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NuevoR.Location = new System.Drawing.Point(25, 130);
            this.btn_NuevoR.Name = "btn_NuevoR";
            this.btn_NuevoR.Size = new System.Drawing.Size(250, 56);
            this.btn_NuevoR.TabIndex = 13;
            this.btn_NuevoR.Text = "Crear Recurso";
            this.btn_NuevoR.UseVisualStyleBackColor = true;
            this.btn_NuevoR.Click += new System.EventHandler(this.btn_NuevoR_Click);
            // 
            // btn_Movimiento
            // 
            this.btn_Movimiento.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Movimiento.Location = new System.Drawing.Point(25, 130);
            this.btn_Movimiento.Name = "btn_Movimiento";
            this.btn_Movimiento.Size = new System.Drawing.Size(250, 56);
            this.btn_Movimiento.TabIndex = 14;
            this.btn_Movimiento.Text = "Crear Movimiento de Inventario";
            this.btn_Movimiento.UseVisualStyleBackColor = true;
            this.btn_Movimiento.Click += new System.EventHandler(this.btn_Movimiento_Click);
            // 
            // btn_Editar
            // 
            this.btn_Editar.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Editar.Location = new System.Drawing.Point(25, 230);
            this.btn_Editar.Name = "btn_Editar";
            this.btn_Editar.Size = new System.Drawing.Size(250, 56);
            this.btn_Editar.TabIndex = 15;
            this.btn_Editar.Text = "Editar Recurso";
            this.btn_Editar.UseVisualStyleBackColor = true;
            this.btn_Editar.Click += new System.EventHandler(this.btn_Editar_Click);
            // 
            // radio_Recursos
            // 
            this.radio_Recursos.AutoSize = true;
            this.radio_Recursos.Checked = true;
            this.radio_Recursos.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Recursos.Location = new System.Drawing.Point(390, 85);
            this.radio_Recursos.Name = "radio_Recursos";
            this.radio_Recursos.Size = new System.Drawing.Size(94, 22);
            this.radio_Recursos.TabIndex = 16;
            this.radio_Recursos.TabStop = true;
            this.radio_Recursos.Text = "Recursos";
            this.radio_Recursos.UseVisualStyleBackColor = true;
            this.radio_Recursos.CheckedChanged += new System.EventHandler(this.radio_Recursos_CheckedChanged);
            // 
            // radio_Movimientos
            // 
            this.radio_Movimientos.AutoSize = true;
            this.radio_Movimientos.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Movimientos.Location = new System.Drawing.Point(635, 85);
            this.radio_Movimientos.Name = "radio_Movimientos";
            this.radio_Movimientos.Size = new System.Drawing.Size(121, 22);
            this.radio_Movimientos.TabIndex = 17;
            this.radio_Movimientos.Text = "Movimientos";
            this.radio_Movimientos.UseVisualStyleBackColor = true;
            this.radio_Movimientos.CheckedChanged += new System.EventHandler(this.radio_Movimientos_CheckedChanged);
            // 
            // radio_Jaulas
            // 
            this.radio_Jaulas.AutoSize = true;
            this.radio_Jaulas.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Jaulas.Location = new System.Drawing.Point(900, 85);
            this.radio_Jaulas.Name = "radio_Jaulas";
            this.radio_Jaulas.Size = new System.Drawing.Size(71, 22);
            this.radio_Jaulas.TabIndex = 18;
            this.radio_Jaulas.Text = "Jaulas";
            this.radio_Jaulas.UseVisualStyleBackColor = true;
            this.radio_Jaulas.CheckedChanged += new System.EventHandler(this.radio_Jaulas_CheckedChanged);
            // 
            // tbl_Movimientos
            // 
            this.tbl_Movimientos.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.tbl_Movimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Movimientos.Location = new System.Drawing.Point(300, 120);
            this.tbl_Movimientos.Name = "tbl_Movimientos";
            this.tbl_Movimientos.Size = new System.Drawing.Size(770, 440);
            this.tbl_Movimientos.TabIndex = 19;
            // 
            // tbl_Jaulas
            // 
            this.tbl_Jaulas.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.tbl_Jaulas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbl_Jaulas.Location = new System.Drawing.Point(300, 120);
            this.tbl_Jaulas.Name = "tbl_Jaulas";
            this.tbl_Jaulas.Size = new System.Drawing.Size(770, 440);
            this.tbl_Jaulas.TabIndex = 20;
            // 
            // btn_NuevaJaula
            // 
            this.btn_NuevaJaula.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NuevaJaula.Location = new System.Drawing.Point(25, 130);
            this.btn_NuevaJaula.Name = "btn_NuevaJaula";
            this.btn_NuevaJaula.Size = new System.Drawing.Size(250, 56);
            this.btn_NuevaJaula.TabIndex = 21;
            this.btn_NuevaJaula.Text = "Nueva Jaula";
            this.btn_NuevaJaula.UseVisualStyleBackColor = true;
            this.btn_NuevaJaula.Click += new System.EventHandler(this.btn_NuevaJaula_Click);
            // 
            // btn_EliminarJaula
            // 
            this.btn_EliminarJaula.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarJaula.Location = new System.Drawing.Point(25, 490);
            this.btn_EliminarJaula.Name = "btn_EliminarJaula";
            this.btn_EliminarJaula.Size = new System.Drawing.Size(250, 56);
            this.btn_EliminarJaula.TabIndex = 22;
            this.btn_EliminarJaula.Text = "Eliminar Jaula";
            this.btn_EliminarJaula.UseVisualStyleBackColor = true;
            this.btn_EliminarJaula.Click += new System.EventHandler(this.btn_EliminarJaula_Click);
            // 
            // btn_MoverAnimal
            // 
            this.btn_MoverAnimal.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MoverAnimal.Location = new System.Drawing.Point(25, 230);
            this.btn_MoverAnimal.Name = "btn_MoverAnimal";
            this.btn_MoverAnimal.Size = new System.Drawing.Size(250, 56);
            this.btn_MoverAnimal.TabIndex = 23;
            this.btn_MoverAnimal.Text = "Mover Animal";
            this.btn_MoverAnimal.UseVisualStyleBackColor = true;
            this.btn_MoverAnimal.Click += new System.EventHandler(this.btn_MoverAnimal_Click);
            // 
            // btn_EliminarRecurso
            // 
            this.btn_EliminarRecurso.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_EliminarRecurso.Location = new System.Drawing.Point(25, 490);
            this.btn_EliminarRecurso.Name = "btn_EliminarRecurso";
            this.btn_EliminarRecurso.Size = new System.Drawing.Size(250, 56);
            this.btn_EliminarRecurso.TabIndex = 24;
            this.btn_EliminarRecurso.Text = "Eliminar Recurso";
            this.btn_EliminarRecurso.UseVisualStyleBackColor = true;
            this.btn_EliminarRecurso.Click += new System.EventHandler(this.btn_EliminarRecurso_Click);
            // 
            // Recursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.btn_EliminarRecurso);
            this.Controls.Add(this.btn_MoverAnimal);
            this.Controls.Add(this.btn_EliminarJaula);
            this.Controls.Add(this.btn_NuevaJaula);
            this.Controls.Add(this.tbl_Jaulas);
            this.Controls.Add(this.tbl_Movimientos);
            this.Controls.Add(this.radio_Jaulas);
            this.Controls.Add(this.radio_Movimientos);
            this.Controls.Add(this.radio_Recursos);
            this.Controls.Add(this.btn_Editar);
            this.Controls.Add(this.btn_Movimiento);
            this.Controls.Add(this.btn_NuevoR);
            this.Controls.Add(this.tbl_Recursos);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Recursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recursos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Recursos_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Recursos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Movimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbl_Jaulas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.DataGridView tbl_Recursos;
        private System.Windows.Forms.Button btn_NuevoR;
        private System.Windows.Forms.Button btn_Movimiento;
        private System.Windows.Forms.Button btn_Editar;
        private System.Windows.Forms.RadioButton radio_Recursos;
        private System.Windows.Forms.RadioButton radio_Movimientos;
        private System.Windows.Forms.RadioButton radio_Jaulas;
        private System.Windows.Forms.DataGridView tbl_Movimientos;
        private System.Windows.Forms.DataGridView tbl_Jaulas;
        private System.Windows.Forms.Button btn_NuevaJaula;
        private System.Windows.Forms.Button btn_EliminarJaula;
        private System.Windows.Forms.Button btn_MoverAnimal;
        private System.Windows.Forms.Button btn_EliminarRecurso;
    }
}