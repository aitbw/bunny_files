﻿namespace bunny_files
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.usb_devices = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.formulario = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione la unidad a formatear:";
            // 
            // usb_devices
            // 
            this.usb_devices.FormattingEnabled = true;
            this.usb_devices.Location = new System.Drawing.Point(226, 10);
            this.usb_devices.Name = "usb_devices";
            this.usb_devices.Size = new System.Drawing.Size(121, 21);
            this.usb_devices.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cargue el PDF a editar:";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Location = new System.Drawing.Point(358, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Formatear unidad y escribir PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.Location = new System.Drawing.Point(165, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Seleccionar archivo";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // formulario
            // 
            this.formulario.AutoSize = true;
            this.formulario.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formulario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.formulario.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.formulario.Location = new System.Drawing.Point(16, 106);
            this.formulario.Name = "formulario";
            this.formulario.Size = new System.Drawing.Size(4, 4);
            this.formulario.TabIndex = 6;
            this.formulario.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(548, 261);
            this.Controls.Add(this.formulario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.usb_devices);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Bunny Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox usb_devices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel formulario;
    }
}

