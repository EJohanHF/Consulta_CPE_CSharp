
namespace Consulta_Masiva_Boletas_Facturas
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
            this.LblPath = new System.Windows.Forms.Label();
            this.BtnPath = new System.Windows.Forms.Button();
            this.BtnLeer = new System.Windows.Forms.Button();
            this.TblDatosLeidos = new System.Windows.Forms.DataGridView();
            this.TxtSeparadorCampos = new System.Windows.Forms.TextBox();
            this.txtSeparadorValores = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ChkEncabezado = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TblDatosLeidos)).BeginInit();
            this.SuspendLayout();
            // 
            // LblPath
            // 
            this.LblPath.AutoSize = true;
            this.LblPath.Location = new System.Drawing.Point(129, 17);
            this.LblPath.Name = "LblPath";
            this.LblPath.Size = new System.Drawing.Size(35, 13);
            this.LblPath.TabIndex = 0;
            this.LblPath.Text = "label1";
            // 
            // BtnPath
            // 
            this.BtnPath.Location = new System.Drawing.Point(33, 12);
            this.BtnPath.Name = "BtnPath";
            this.BtnPath.Size = new System.Drawing.Size(75, 23);
            this.BtnPath.TabIndex = 1;
            this.BtnPath.Text = "...";
            this.BtnPath.UseVisualStyleBackColor = true;
            this.BtnPath.Click += new System.EventHandler(this.BtnPath_Click);
            // 
            // BtnLeer
            // 
            this.BtnLeer.Location = new System.Drawing.Point(36, 161);
            this.BtnLeer.Name = "BtnLeer";
            this.BtnLeer.Size = new System.Drawing.Size(75, 23);
            this.BtnLeer.TabIndex = 2;
            this.BtnLeer.Text = "Leer";
            this.BtnLeer.UseVisualStyleBackColor = true;
            this.BtnLeer.Click += new System.EventHandler(this.BtnLeer_Click);
            // 
            // TblDatosLeidos
            // 
            this.TblDatosLeidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TblDatosLeidos.Location = new System.Drawing.Point(33, 214);
            this.TblDatosLeidos.Name = "TblDatosLeidos";
            this.TblDatosLeidos.Size = new System.Drawing.Size(810, 298);
            this.TblDatosLeidos.TabIndex = 3;
            // 
            // TxtSeparadorCampos
            // 
            this.TxtSeparadorCampos.Location = new System.Drawing.Point(215, 45);
            this.TxtSeparadorCampos.Name = "TxtSeparadorCampos";
            this.TxtSeparadorCampos.Size = new System.Drawing.Size(32, 20);
            this.TxtSeparadorCampos.TabIndex = 4;
            // 
            // txtSeparadorValores
            // 
            this.txtSeparadorValores.Location = new System.Drawing.Point(215, 85);
            this.txtSeparadorValores.Name = "txtSeparadorValores";
            this.txtSeparadorValores.Size = new System.Drawing.Size(32, 20);
            this.txtSeparadorValores.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Carater Separador De Campos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Caracter Separador de Valores";
            // 
            // ChkEncabezado
            // 
            this.ChkEncabezado.AutoSize = true;
            this.ChkEncabezado.Location = new System.Drawing.Point(215, 126);
            this.ChkEncabezado.Name = "ChkEncabezado";
            this.ChkEncabezado.Size = new System.Drawing.Size(15, 14);
            this.ChkEncabezado.TabIndex = 8;
            this.ChkEncabezado.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tiene Encabezados";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChkEncabezado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSeparadorValores);
            this.Controls.Add(this.TxtSeparadorCampos);
            this.Controls.Add(this.TblDatosLeidos);
            this.Controls.Add(this.BtnLeer);
            this.Controls.Add(this.BtnPath);
            this.Controls.Add(this.LblPath);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.TblDatosLeidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblPath;
        private System.Windows.Forms.Button BtnPath;
        private System.Windows.Forms.Button BtnLeer;
        private System.Windows.Forms.DataGridView TblDatosLeidos;
        private System.Windows.Forms.TextBox TxtSeparadorCampos;
        private System.Windows.Forms.TextBox txtSeparadorValores;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ChkEncabezado;
        private System.Windows.Forms.Label label3;
    }
}

