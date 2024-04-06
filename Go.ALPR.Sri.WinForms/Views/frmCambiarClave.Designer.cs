
namespace Go.ALPR.Sri.WinForms
{
    partial class frmCambiarClave
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
            this.txtClaveRepetida = new System.Windows.Forms.TextBox();
            this.txtClaveNueva = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtClaveAnterior = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtClaveRepetida
            // 
            this.txtClaveRepetida.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClaveRepetida.Location = new System.Drawing.Point(34, 130);
            this.txtClaveRepetida.MaxLength = 20;
            this.txtClaveRepetida.Name = "txtClaveRepetida";
            this.txtClaveRepetida.PlaceholderText = "Repita clave nueva";
            this.txtClaveRepetida.Size = new System.Drawing.Size(277, 39);
            this.txtClaveRepetida.TabIndex = 2;
            this.txtClaveRepetida.UseSystemPasswordChar = true;
            // 
            // txtClaveNueva
            // 
            this.txtClaveNueva.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClaveNueva.Location = new System.Drawing.Point(34, 71);
            this.txtClaveNueva.MaxLength = 20;
            this.txtClaveNueva.Name = "txtClaveNueva";
            this.txtClaveNueva.PlaceholderText = "Nueva clave";
            this.txtClaveNueva.Size = new System.Drawing.Size(277, 39);
            this.txtClaveNueva.TabIndex = 1;
            this.txtClaveNueva.UseSystemPasswordChar = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.cancelar;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Location = new System.Drawing.Point(60, 190);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(60, 60);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackgroundImage = global::Go.ALPR.Sri.WinForms.Properties.Resources.aceptar;
            this.btnAceptar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAceptar.Location = new System.Drawing.Point(225, 190);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(60, 60);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtClaveAnterior
            // 
            this.txtClaveAnterior.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtClaveAnterior.Location = new System.Drawing.Point(34, 12);
            this.txtClaveAnterior.MaxLength = 20;
            this.txtClaveAnterior.Name = "txtClaveAnterior";
            this.txtClaveAnterior.PlaceholderText = "Clave anterior";
            this.txtClaveAnterior.Size = new System.Drawing.Size(277, 39);
            this.txtClaveAnterior.TabIndex = 0;
            this.txtClaveAnterior.UseSystemPasswordChar = true;
            // 
            // frmCambiarClave
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(344, 260);
            this.ControlBox = false;
            this.Controls.Add(this.txtClaveAnterior);
            this.Controls.Add(this.txtClaveRepetida);
            this.Controls.Add(this.txtClaveNueva);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmCambiarClave";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio de clave";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtClaveRepetida;
        private System.Windows.Forms.TextBox txtClaveNueva;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtClaveAnterior;
    }
}