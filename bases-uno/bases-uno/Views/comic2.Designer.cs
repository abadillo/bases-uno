
namespace bases_uno.Views
{
    partial class comic2
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
            this.mnpanel1 = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.stpanel7.SuspendLayout();
            this.dipanel1.SuspendLayout();
            this.mnpanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stpanel7
            // 
            this.stpanel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(46)))), ((int)(((byte)(58)))));
            this.stpanel7.Controls.Add(this.dipanel1);
            this.stpanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stpanel7.Location = new System.Drawing.Point(0, 0);
            this.stpanel7.Margin = new System.Windows.Forms.Padding(0);
            this.stpanel7.Name = "stpanel7";
            this.stpanel7.Padding = new System.Windows.Forms.Padding(15);
            this.stpanel7.Size = new System.Drawing.Size(864, 529);
            this.stpanel7.TabIndex = 1;
            // 
            // dipanel1
            // 
            this.dipanel1.Controls.Add(this.mnpanel1);
            this.dipanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dipanel1.Location = new System.Drawing.Point(15, 15);
            this.dipanel1.Name = "dipanel1";
            this.dipanel1.Size = new System.Drawing.Size(834, 499);
            this.dipanel1.TabIndex = 0;
            // 
            // mnpanel1
            // 
            this.mnpanel1.Controls.Add(this.reportViewer1);
            this.mnpanel1.Controls.Add(this.label2);
            this.mnpanel1.Controls.Add(this.vScrollBar1);
            this.mnpanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnpanel1.Location = new System.Drawing.Point(0, 0);
            this.mnpanel1.Name = "mnpanel1";
            this.mnpanel1.Size = new System.Drawing.Size(834, 499);
            this.mnpanel1.TabIndex = 9;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 40);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(820, 459);
            this.reportViewer1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(820, 40);
            this.label2.TabIndex = 20;
            this.label2.Text = "Ficha Comic";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(820, 0);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(14, 499);
            this.vScrollBar1.TabIndex = 0;
            this.vScrollBar1.Visible = false;
            // 
            // comic2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 529);
            this.Controls.Add(this.stpanel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "comic2";
            this.Text = "8 Bit Subastas";
            this.Load += new System.EventHandler(this.comic2_Load);
            this.stpanel7.ResumeLayout(false);
            this.dipanel1.ResumeLayout(false);
            this.mnpanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel stpanel7;
        private System.Windows.Forms.Panel dipanel1;
        private System.Windows.Forms.Panel mnpanel1;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label2;
    }
}