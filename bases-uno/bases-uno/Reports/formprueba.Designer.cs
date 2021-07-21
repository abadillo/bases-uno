
namespace bases_uno.Reports
{
    partial class formprueba
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.jagclubBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prueba = new bases_uno.Reports.DataSets.prueba();
            this.pruebaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.jagclubTableAdapter = new bases_uno.Reports.DataSets.pruebaTableAdapters.jagclubTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.jagclubBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prueba)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "pruebadataset";
            reportDataSource1.Value = this.jagclubBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "bases_uno.Reports.pruebaRDLC.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(10, 10);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(860, 607);
            this.reportViewer1.TabIndex = 0;
            // 
            // jagclubBindingSource
            // 
            this.jagclubBindingSource.DataMember = "jagclub";
            this.jagclubBindingSource.DataSource = this.pruebaBindingSource;
            // 
            // prueba
            // 
            this.prueba.DataSetName = "prueba";
            this.prueba.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pruebaBindingSource
            // 
            this.pruebaBindingSource.DataSource = this.prueba;
            this.pruebaBindingSource.Position = 0;
            // 
            // jagclubTableAdapter
            // 
            this.jagclubTableAdapter.ClearBeforeFill = true;
            // 
            // formprueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 627);
            this.Controls.Add(this.reportViewer1);
            this.Name = "formprueba";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "formprueba";
            this.Load += new System.EventHandler(this.formprueba_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jagclubBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prueba)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pruebaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSets.prueba prueba;
        private System.Windows.Forms.BindingSource pruebaBindingSource;
        private System.Windows.Forms.BindingSource jagclubBindingSource;
        private DataSets.pruebaTableAdapters.jagclubTableAdapter jagclubTableAdapter;
    }
}