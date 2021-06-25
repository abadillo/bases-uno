
namespace bases_uno.Views
{
    partial class Reporte_comic
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
            this.comicDataSet = new bases_uno.Reports.DataSets.ComicDataSet();
            this.comicDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.comicDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comicDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.comicDataSetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "bases_uno.Reports.ComicReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 15);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1050, 487);
            this.reportViewer1.TabIndex = 0;
            // 
            // comicDataSet
            // 
            this.comicDataSet.DataSetName = "ComicDataSet";
            this.comicDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comicDataSetBindingSource
            // 
            this.comicDataSetBindingSource.DataSource = this.comicDataSet;
            this.comicDataSetBindingSource.Position = 0;
            // 
            // Reporte_comic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Reporte_comic";
            this.Text = "Reporte_comic";
            this.Load += new System.EventHandler(this.Reporte_comic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comicDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comicDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource comicDataSetBindingSource;
        private Reports.DataSets.ComicDataSet comicDataSet;
    }
}