
namespace bases_uno.Views
{
    partial class comicl
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
            this.stpanel7 = new System.Windows.Forms.Panel();
            this.dipanel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hrpanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnadelante = new FontAwesome.Sharp.IconButton();
            this.btnatras = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.stpanel7.SuspendLayout();
            this.dipanel1.SuspendLayout();
            this.hrpanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpanel7
            // 
            this.stpanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(46)))), ((int)(((byte)(58)))));
            this.stpanel7.Controls.Add(this.dipanel1);
            this.stpanel7.Controls.Add(this.panel1);
            this.stpanel7.Controls.Add(this.hrpanel);
            this.stpanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stpanel7.Location = new System.Drawing.Point(0, 0);
            this.stpanel7.Margin = new System.Windows.Forms.Padding(0);
            this.stpanel7.Name = "stpanel7";
            this.stpanel7.Padding = new System.Windows.Forms.Padding(15);
            this.stpanel7.Size = new System.Drawing.Size(864, 757);
            this.stpanel7.TabIndex = 1;
            this.stpanel7.Paint += new System.Windows.Forms.PaintEventHandler(this.stpanel7_Paint);
            // 
            // dipanel1
            // 
            this.dipanel1.Controls.Add(this.flowLayoutPanel1);
            this.dipanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dipanel1.Location = new System.Drawing.Point(15, 78);
            this.dipanel1.Name = "dipanel1";
            this.dipanel1.Size = new System.Drawing.Size(834, 664);
            this.dipanel1.TabIndex = 12;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(834, 664);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(15, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(834, 15);
            this.panel1.TabIndex = 11;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // hrpanel
            // 
            this.hrpanel.Controls.Add(this.panel2);
            this.hrpanel.Controls.Add(this.label1);
            this.hrpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.hrpanel.Location = new System.Drawing.Point(15, 15);
            this.hrpanel.Name = "hrpanel";
            this.hrpanel.Size = new System.Drawing.Size(834, 48);
            this.hrpanel.TabIndex = 10;
            this.hrpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.hrpanel_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnadelante);
            this.panel2.Controls.Add(this.btnatras);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(694, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 48);
            this.panel2.TabIndex = 1;
            // 
            // btnadelante
            // 
            this.btnadelante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(46)))), ((int)(((byte)(58)))));
            this.btnadelante.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnadelante.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnadelante.FlatAppearance.BorderSize = 0;
            this.btnadelante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadelante.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            this.btnadelante.IconColor = System.Drawing.Color.LightGray;
            this.btnadelante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnadelante.Location = new System.Drawing.Point(74, 0);
            this.btnadelante.Margin = new System.Windows.Forms.Padding(0);
            this.btnadelante.Name = "btnadelante";
            this.btnadelante.Size = new System.Drawing.Size(66, 48);
            this.btnadelante.TabIndex = 5;
            this.btnadelante.UseVisualStyleBackColor = false;
            this.btnadelante.Visible = false;
            this.btnadelante.Click += new System.EventHandler(this.btnadelante_Click);
            // 
            // btnatras
            // 
            this.btnatras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(46)))), ((int)(((byte)(58)))));
            this.btnatras.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnatras.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro;
            this.btnatras.FlatAppearance.BorderSize = 0;
            this.btnatras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnatras.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnatras.IconColor = System.Drawing.Color.LightGray;
            this.btnatras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnatras.Location = new System.Drawing.Point(0, 0);
            this.btnatras.Margin = new System.Windows.Forms.Padding(0);
            this.btnatras.Name = "btnatras";
            this.btnatras.Size = new System.Drawing.Size(66, 48);
            this.btnatras.TabIndex = 4;
            this.btnatras.UseVisualStyleBackColor = false;
            this.btnatras.Visible = false;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 51);
            this.label1.TabIndex = 0;
            // 
            // comicl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 757);
            this.Controls.Add(this.stpanel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "comicl";
            this.Text = "8 Bit Subastas";
            this.Load += new System.EventHandler(this.comicl_Load);
            this.stpanel7.ResumeLayout(false);
            this.dipanel1.ResumeLayout(false);
            this.hrpanel.ResumeLayout(false);
            this.hrpanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel stpanel7;
        private System.Windows.Forms.Panel dipanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel hrpanel;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btnadelante;
        private FontAwesome.Sharp.IconButton btnatras;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}