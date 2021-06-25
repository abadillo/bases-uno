
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.stpanel7 = new System.Windows.Forms.Panel();
            this.dipanel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hrpanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnadelante = new FontAwesome.Sharp.IconButton();
            this.btnatras = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comicDataSet = new bases_uno.Reports.DataSets.ComicDataSet();
            this.comicBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comicTableAdapter = new bases_uno.Reports.DataSets.ComicDataSetTableAdapters.comicTableAdapter();
            this.stpanel7.SuspendLayout();
            this.dipanel1.SuspendLayout();
            this.hrpanel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comicBindingSource)).BeginInit();
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
            this.stpanel7.Padding = new System.Windows.Forms.Padding(20, 18, 20, 18);
            this.stpanel7.Size = new System.Drawing.Size(1152, 987);
            this.stpanel7.TabIndex = 1;
            // 
            // dipanel1
            // 
            this.dipanel1.AutoScroll = true;
            this.dipanel1.Controls.Add(this.reportViewer1);
            this.dipanel1.Controls.Add(this.label2);
            this.dipanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dipanel1.Location = new System.Drawing.Point(20, 132);
            this.dipanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dipanel1.Name = "dipanel1";
            this.dipanel1.Padding = new System.Windows.Forms.Padding(0, 0, 24, 0);
            this.dipanel1.Size = new System.Drawing.Size(1112, 837);
            this.dipanel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.LightGray;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1112, 49);
            this.label2.TabIndex = 22;
            this.label2.Text = "Ficha Comic";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(20, 82);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1112, 50);
            this.panel1.TabIndex = 13;
            // 
            // hrpanel
            // 
            this.hrpanel.Controls.Add(this.panel2);
            this.hrpanel.Controls.Add(this.label1);
            this.hrpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.hrpanel.Location = new System.Drawing.Point(20, 18);
            this.hrpanel.Margin = new System.Windows.Forms.Padding(4);
            this.hrpanel.Name = "hrpanel";
            this.hrpanel.Size = new System.Drawing.Size(1112, 64);
            this.hrpanel.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnadelante);
            this.panel2.Controls.Add(this.btnatras);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(925, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(187, 64);
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
            this.btnadelante.Location = new System.Drawing.Point(99, 0);
            this.btnadelante.Margin = new System.Windows.Forms.Padding(0);
            this.btnadelante.Name = "btnadelante";
            this.btnadelante.Size = new System.Drawing.Size(88, 64);
            this.btnadelante.TabIndex = 5;
            this.btnadelante.UseVisualStyleBackColor = false;
            this.btnadelante.Visible = false;
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
            this.btnatras.Size = new System.Drawing.Size(88, 64);
            this.btnatras.TabIndex = 4;
            this.btnatras.UseVisualStyleBackColor = false;
            this.btnatras.Click += new System.EventHandler(this.btnatras_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F);
            this.label1.ForeColor = System.Drawing.Color.LightGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 63);
            this.label1.TabIndex = 0;
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.comicBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "bases_uno.Reports.ComicReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 52);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1112, 524);
            this.reportViewer1.TabIndex = 23;
            // 
            // comicDataSet
            // 
            this.comicDataSet.DataSetName = "ComicDataSet";
            this.comicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comicBindingSource
            // 
            this.comicBindingSource.DataMember = "comic";
            this.comicBindingSource.DataSource = this.comicDataSet;
            // 
            // comicTableAdapter
            // 
            this.comicTableAdapter.ClearBeforeFill = true;
            // 
            // comic2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 987);
            this.Controls.Add(this.stpanel7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "comic2";
            this.Text = "8 Bit Subastas";
            this.Load += new System.EventHandler(this.comic2_Load);
            this.stpanel7.ResumeLayout(false);
            this.dipanel1.ResumeLayout(false);
            this.hrpanel.ResumeLayout(false);
            this.hrpanel.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comicBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private Reports.DataSets.ComicDataSet comicDataSet;
        private System.Windows.Forms.BindingSource comicBindingSource;
        private Reports.DataSets.ComicDataSetTableAdapters.comicTableAdapter comicTableAdapter;
    }
}