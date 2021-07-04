
namespace bases_uno.Views.UserControls.Submenus
{
    partial class menucoleccionable
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
            this.dipanel = new System.Windows.Forms.Panel();
            this.buttonRegistro = new System.Windows.Forms.Button();
            this.buttonListado = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTitulo = new System.Windows.Forms.Label();
            this.dipanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dipanel
            // 
            this.dipanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(69)))), ((int)(((byte)(89)))));
            this.dipanel.Controls.Add(this.buttonRegistro);
            this.dipanel.Controls.Add(this.buttonListado);
            this.dipanel.Controls.Add(this.panel1);
            this.dipanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dipanel.Location = new System.Drawing.Point(0, 0);
            this.dipanel.Name = "dipanel";
            this.dipanel.Padding = new System.Windows.Forms.Padding(1);
            this.dipanel.Size = new System.Drawing.Size(218, 464);
            this.dipanel.TabIndex = 2;
            // 
            // buttonRegistro
            // 
            this.buttonRegistro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(84)))), ((int)(((byte)(110)))));
            this.buttonRegistro.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonRegistro.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonRegistro.FlatAppearance.BorderSize = 0;
            this.buttonRegistro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistro.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistro.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonRegistro.Location = new System.Drawing.Point(1, 104);
            this.buttonRegistro.Name = "buttonRegistro";
            this.buttonRegistro.Size = new System.Drawing.Size(216, 50);
            this.buttonRegistro.TabIndex = 6;
            this.buttonRegistro.Text = "Registro";
            this.buttonRegistro.UseVisualStyleBackColor = false;
            this.buttonRegistro.Click += new System.EventHandler(this.buttonRegistro_Click);
            // 
            // buttonListado
            // 
            this.buttonListado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(84)))), ((int)(((byte)(110)))));
            this.buttonListado.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonListado.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.buttonListado.FlatAppearance.BorderSize = 0;
            this.buttonListado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonListado.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonListado.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonListado.Location = new System.Drawing.Point(1, 54);
            this.buttonListado.Name = "buttonListado";
            this.buttonListado.Size = new System.Drawing.Size(216, 50);
            this.buttonListado.TabIndex = 5;
            this.buttonListado.Text = "Listado";
            this.buttonListado.UseVisualStyleBackColor = false;
            this.buttonListado.Click += new System.EventHandler(this.buttonListado_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 53);
            this.panel1.TabIndex = 4;
            // 
            // labelTitulo
            // 
            this.labelTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(103)))), ((int)(((byte)(135)))));
            this.labelTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitulo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelTitulo.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelTitulo.Location = new System.Drawing.Point(0, 0);
            this.labelTitulo.Name = "labelTitulo";
            this.labelTitulo.Size = new System.Drawing.Size(216, 53);
            this.labelTitulo.TabIndex = 3;
            this.labelTitulo.Text = "Coleccionables";
            this.labelTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menucoleccionable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(218, 464);
            this.Controls.Add(this.dipanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "menucoleccionable";
            this.Text = "menucomic";
            this.dipanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel dipanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTitulo;
        private System.Windows.Forms.Button buttonRegistro;
        private System.Windows.Forms.Button buttonListado;
    }
}