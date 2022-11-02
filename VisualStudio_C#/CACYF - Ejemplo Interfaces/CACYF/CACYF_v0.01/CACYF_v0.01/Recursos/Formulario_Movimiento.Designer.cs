namespace CACYF_v0._01
{
    partial class Formulario_Movimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulario_Movimiento));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Crear = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Cantidad = new System.Windows.Forms.TextBox();
            this.radio_Mas = new System.Windows.Forms.RadioButton();
            this.radio_Menos = new System.Windows.Forms.RadioButton();
            this.txtbox_Movimiento = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccionar Recurso";
            // 
            // btn_Crear
            // 
            this.btn_Crear.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Crear.Location = new System.Drawing.Point(300, 180);
            this.btn_Crear.Name = "btn_Crear";
            this.btn_Crear.Size = new System.Drawing.Size(100, 30);
            this.btn_Crear.TabIndex = 5;
            this.btn_Crear.Text = "Crear";
            this.btn_Crear.UseVisualStyleBackColor = true;
            this.btn_Crear.Click += new System.EventHandler(this.btn_Crear_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(50, 180);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(100, 30);
            this.btn_Cancelar.TabIndex = 6;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(66, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Cantidad";
            // 
            // txt_Cantidad
            // 
            this.txt_Cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Cantidad.Location = new System.Drawing.Point(210, 70);
            this.txt_Cantidad.Name = "txt_Cantidad";
            this.txt_Cantidad.Size = new System.Drawing.Size(260, 24);
            this.txt_Cantidad.TabIndex = 9;
            // 
            // radio_Mas
            // 
            this.radio_Mas.AutoSize = true;
            this.radio_Mas.BackColor = System.Drawing.Color.Transparent;
            this.radio_Mas.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Mas.ForeColor = System.Drawing.Color.White;
            this.radio_Mas.Location = new System.Drawing.Point(210, 117);
            this.radio_Mas.Name = "radio_Mas";
            this.radio_Mas.Size = new System.Drawing.Size(110, 20);
            this.radio_Mas.TabIndex = 10;
            this.radio_Mas.TabStop = true;
            this.radio_Mas.Text = "Aumento (+)";
            this.radio_Mas.UseVisualStyleBackColor = false;
            // 
            // radio_Menos
            // 
            this.radio_Menos.AutoSize = true;
            this.radio_Menos.BackColor = System.Drawing.Color.Transparent;
            this.radio_Menos.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_Menos.ForeColor = System.Drawing.Color.White;
            this.radio_Menos.Location = new System.Drawing.Point(341, 117);
            this.radio_Menos.Name = "radio_Menos";
            this.radio_Menos.Size = new System.Drawing.Size(129, 20);
            this.radio_Menos.TabIndex = 11;
            this.radio_Menos.TabStop = true;
            this.radio_Menos.Text = "Decremento (-)";
            this.radio_Menos.UseVisualStyleBackColor = false;
            // 
            // txtbox_Movimiento
            // 
            this.txtbox_Movimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_Movimiento.FormattingEnabled = true;
            this.txtbox_Movimiento.Location = new System.Drawing.Point(210, 30);
            this.txtbox_Movimiento.Name = "txtbox_Movimiento";
            this.txtbox_Movimiento.Size = new System.Drawing.Size(260, 24);
            this.txtbox_Movimiento.TabIndex = 17;
            // 
            // Formulario_Movimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(484, 221);
            this.Controls.Add(this.txtbox_Movimiento);
            this.Controls.Add(this.radio_Menos);
            this.Controls.Add(this.radio_Mas);
            this.Controls.Add(this.txt_Cantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Crear);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Formulario_Movimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Recursos - Crear Movimiento de Inventario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Crear;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Cantidad;
        private System.Windows.Forms.RadioButton radio_Mas;
        private System.Windows.Forms.RadioButton radio_Menos;
        private System.Windows.Forms.ComboBox txtbox_Movimiento;
    }
}