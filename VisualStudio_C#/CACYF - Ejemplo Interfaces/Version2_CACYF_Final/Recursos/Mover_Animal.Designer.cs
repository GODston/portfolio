namespace Version2_CACYF_Final.Recursos
{
    partial class Mover_Animal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mover_Animal));
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Mover = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_JaulaDestino = new System.Windows.Forms.ComboBox();
            this.txtbox_Animal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancelar.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.Location = new System.Drawing.Point(59, 154);
            this.btn_Cancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(133, 37);
            this.btn_Cancelar.TabIndex = 28;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Mover
            // 
            this.btn_Mover.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Mover.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Mover.Location = new System.Drawing.Point(392, 154);
            this.btn_Mover.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Mover.Name = "btn_Mover";
            this.btn_Mover.Size = new System.Drawing.Size(133, 37);
            this.btn_Mover.TabIndex = 27;
            this.btn_Mover.Text = "Mover";
            this.btn_Mover.UseVisualStyleBackColor = true;
            this.btn_Mover.Click += new System.EventHandler(this.btn_Mover_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 23);
            this.label1.TabIndex = 26;
            this.label1.Text = "Jaula Destino";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 23);
            this.label4.TabIndex = 25;
            this.label4.Text = "Seleccione Animal";
            // 
            // txtbox_JaulaDestino
            // 
            this.txtbox_JaulaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtbox_JaulaDestino.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_JaulaDestino.FormattingEnabled = true;
            this.txtbox_JaulaDestino.Location = new System.Drawing.Point(272, 80);
            this.txtbox_JaulaDestino.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbox_JaulaDestino.Name = "txtbox_JaulaDestino";
            this.txtbox_JaulaDestino.Size = new System.Drawing.Size(345, 28);
            this.txtbox_JaulaDestino.TabIndex = 24;
            // 
            // txtbox_Animal
            // 
            this.txtbox_Animal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtbox_Animal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbox_Animal.FormattingEnabled = true;
            this.txtbox_Animal.Location = new System.Drawing.Point(272, 31);
            this.txtbox_Animal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtbox_Animal.Name = "txtbox_Animal";
            this.txtbox_Animal.Size = new System.Drawing.Size(345, 28);
            this.txtbox_Animal.TabIndex = 23;
            // 
            // Mover_Animal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Version2_CACYF_Final.Properties.Resources.menu_principal;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(645, 223);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Mover);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtbox_JaulaDestino);
            this.Controls.Add(this.txtbox_Animal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Mover_Animal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mover Animal";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Mover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox txtbox_JaulaDestino;
        private System.Windows.Forms.ComboBox txtbox_Animal;
    }
}