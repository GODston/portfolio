namespace Mochila_Multivalores02
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_cap = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_file = new System.Windows.Forms.TextBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.txt_sol = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rigual = new System.Windows.Forms.TextBox();
            this.rmas = new System.Windows.Forms.TextBox();
            this.rmay = new System.Windows.Forms.TextBox();
            this.rmen = new System.Windows.Forms.TextBox();
            this.r1 = new System.Windows.Forms.TextBox();
            this.r2 = new System.Windows.Forms.TextBox();
            this.r3 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtcant = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.penalizacion = new System.Windows.Forms.CheckBox();
            this.restricciones = new System.Windows.Forms.CheckBox();
            this.txtpenp = new System.Windows.Forms.TextBox();
            this.txt = new System.Windows.Forms.CheckBox();
            this.manual = new System.Windows.Forms.CheckBox();
            this.aleat = new System.Windows.Forms.CheckBox();
            this.Manualtxt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_v = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtpenv = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cap. de Peso de la Mochila:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 169);
            this.label2.TabIndex = 1;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // txt_cap
            // 
            this.txt_cap.Location = new System.Drawing.Point(180, 6);
            this.txt_cap.Name = "txt_cap";
            this.txt_cap.Size = new System.Drawing.Size(100, 20);
            this.txt_cap.TabIndex = 2;
            this.txt_cap.TextChanged += new System.EventHandler(this.txt_cap_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(633, 160);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Seleccionar Archivo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_file
            // 
            this.txt_file.Enabled = false;
            this.txt_file.Location = new System.Drawing.Point(133, 162);
            this.txt_file.Name = "txt_file";
            this.txt_file.Size = new System.Drawing.Size(494, 20);
            this.txt_file.TabIndex = 4;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(334, 548);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(132, 23);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "Obtener mejor solucion";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_sol
            // 
            this.txt_sol.Enabled = false;
            this.txt_sol.Location = new System.Drawing.Point(175, 497);
            this.txt_sol.Name = "txt_sol";
            this.txt_sol.Size = new System.Drawing.Size(327, 20);
            this.txt_sol.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Restricciones:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(375, 329);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "<=";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(19, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = ">=";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 404);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "+";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(403, 404);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "=";
            // 
            // rigual
            // 
            this.rigual.Location = new System.Drawing.Point(374, 401);
            this.rigual.Name = "rigual";
            this.rigual.Size = new System.Drawing.Size(26, 20);
            this.rigual.TabIndex = 14;
            // 
            // rmas
            // 
            this.rmas.Location = new System.Drawing.Point(331, 401);
            this.rmas.Name = "rmas";
            this.rmas.Size = new System.Drawing.Size(26, 20);
            this.rmas.TabIndex = 15;
            // 
            // rmay
            // 
            this.rmay.Location = new System.Drawing.Point(343, 367);
            this.rmay.Name = "rmay";
            this.rmay.Size = new System.Drawing.Size(26, 20);
            this.rmay.TabIndex = 16;
            // 
            // rmen
            // 
            this.rmen.Location = new System.Drawing.Point(343, 326);
            this.rmen.Name = "rmen";
            this.rmen.Size = new System.Drawing.Size(26, 20);
            this.rmen.TabIndex = 17;
            // 
            // r1
            // 
            this.r1.Location = new System.Drawing.Point(403, 326);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(26, 20);
            this.r1.TabIndex = 18;
            // 
            // r2
            // 
            this.r2.Location = new System.Drawing.Point(403, 367);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(26, 20);
            this.r2.TabIndex = 19;
            // 
            // r3
            // 
            this.r3.Location = new System.Drawing.Point(419, 401);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(26, 20);
            this.r3.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtcant
            // 
            this.txtcant.Location = new System.Drawing.Point(180, 56);
            this.txtcant.Name = "txtcant";
            this.txtcant.Size = new System.Drawing.Size(100, 20);
            this.txtcant.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Cantidad de objetos:";
            // 
            // penalizacion
            // 
            this.penalizacion.AutoSize = true;
            this.penalizacion.Location = new System.Drawing.Point(547, 61);
            this.penalizacion.Name = "penalizacion";
            this.penalizacion.Size = new System.Drawing.Size(100, 17);
            this.penalizacion.TabIndex = 23;
            this.penalizacion.Text = "Penalizaciones:";
            this.penalizacion.UseVisualStyleBackColor = true;
            // 
            // restricciones
            // 
            this.restricciones.AutoSize = true;
            this.restricciones.Location = new System.Drawing.Point(547, 23);
            this.restricciones.Name = "restricciones";
            this.restricciones.Size = new System.Drawing.Size(90, 17);
            this.restricciones.TabIndex = 24;
            this.restricciones.Text = "Restricciones";
            this.restricciones.UseVisualStyleBackColor = true;
            // 
            // txtpenp
            // 
            this.txtpenp.Location = new System.Drawing.Point(644, 52);
            this.txtpenp.Name = "txtpenp";
            this.txtpenp.Size = new System.Drawing.Size(105, 20);
            this.txtpenp.TabIndex = 25;
            // 
            // txt
            // 
            this.txt.AutoSize = true;
            this.txt.Checked = true;
            this.txt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.txt.Location = new System.Drawing.Point(557, 189);
            this.txt.Name = "txt";
            this.txt.Size = new System.Drawing.Size(86, 17);
            this.txt.TabIndex = 26;
            this.txt.Text = "Usar archivo";
            this.txt.UseVisualStyleBackColor = true;
            this.txt.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.Location = new System.Drawing.Point(557, 212);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(100, 17);
            this.manual.TabIndex = 27;
            this.manual.Text = "Entrada manual";
            this.manual.UseVisualStyleBackColor = true;
            this.manual.CheckedChanged += new System.EventHandler(this.manual_CheckedChanged);
            // 
            // aleat
            // 
            this.aleat.AutoSize = true;
            this.aleat.Location = new System.Drawing.Point(557, 235);
            this.aleat.Name = "aleat";
            this.aleat.Size = new System.Drawing.Size(67, 17);
            this.aleat.TabIndex = 28;
            this.aleat.Text = "Aleatorio";
            this.aleat.UseVisualStyleBackColor = true;
            this.aleat.CheckedChanged += new System.EventHandler(this.aleat_CheckedChanged);
            // 
            // Manualtxt
            // 
            this.Manualtxt.Location = new System.Drawing.Point(547, 270);
            this.Manualtxt.Multiline = true;
            this.Manualtxt.Name = "Manualtxt";
            this.Manualtxt.Size = new System.Drawing.Size(241, 284);
            this.Manualtxt.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(554, 255);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Entrada manual:";
            // 
            // txt_v
            // 
            this.txt_v.Location = new System.Drawing.Point(180, 32);
            this.txt_v.Name = "txt_v";
            this.txt_v.Size = new System.Drawing.Size(100, 20);
            this.txt_v.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Cap. de Volúmen de la Mochila:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(751, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 13);
            this.label11.TabIndex = 33;
            this.label11.Text = "Peso";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(751, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Volúmen";
            // 
            // txtpenv
            // 
            this.txtpenv.Location = new System.Drawing.Point(644, 72);
            this.txtpenv.Name = "txtpenv";
            this.txtpenv.Size = new System.Drawing.Size(105, 20);
            this.txtpenv.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 595);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtpenv);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt_v);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Manualtxt);
            this.Controls.Add(this.aleat);
            this.Controls.Add(this.manual);
            this.Controls.Add(this.txt);
            this.Controls.Add(this.txtpenp);
            this.Controls.Add(this.restricciones);
            this.Controls.Add(this.penalizacion);
            this.Controls.Add(this.txtcant);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.r3);
            this.Controls.Add(this.r2);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.rmen);
            this.Controls.Add(this.rmay);
            this.Controls.Add(this.rmas);
            this.Controls.Add(this.rigual);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_sol);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.txt_file);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_cap);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_cap;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_file;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.TextBox txt_sol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox rigual;
        private System.Windows.Forms.TextBox rmas;
        private System.Windows.Forms.TextBox rmay;
        private System.Windows.Forms.TextBox rmen;
        private System.Windows.Forms.TextBox r1;
        private System.Windows.Forms.TextBox r2;
        private System.Windows.Forms.TextBox r3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtcant;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox penalizacion;
        private System.Windows.Forms.CheckBox restricciones;
        private System.Windows.Forms.TextBox txtpenp;
        private System.Windows.Forms.CheckBox txt;
        private System.Windows.Forms.CheckBox manual;
        private System.Windows.Forms.CheckBox aleat;
        private System.Windows.Forms.TextBox Manualtxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_v;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtpenv;
    }
}

