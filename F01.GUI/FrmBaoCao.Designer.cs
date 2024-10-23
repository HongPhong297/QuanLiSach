namespace F01.GUI
{
    partial class FrmBaoCao
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
            this.rptBaoCao = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cboNXB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rptBaoCao
            // 
            this.rptBaoCao.Location = new System.Drawing.Point(12, 87);
            this.rptBaoCao.Name = "rptBaoCao";
            this.rptBaoCao.ServerReport.BearerToken = null;
            this.rptBaoCao.Size = new System.Drawing.Size(776, 426);
            this.rptBaoCao.TabIndex = 0;
            this.rptBaoCao.Load += new System.EventHandler(this.rptBaoCao_Load);
            // 
            // cboNXB
            // 
            this.cboNXB.FormattingEnabled = true;
            this.cboNXB.Location = new System.Drawing.Point(64, 31);
            this.cboNXB.Name = "cboNXB";
            this.cboNXB.Size = new System.Drawing.Size(95, 24);
            this.cboNXB.TabIndex = 32;
            this.cboNXB.SelectedIndexChanged += new System.EventHandler(this.cboNXB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 18);
            this.label2.TabIndex = 33;
            this.label2.Text = "Năm";
            // 
            // FrmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 525);
            this.Controls.Add(this.cboNXB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rptBaoCao);
            this.Name = "FrmBaoCao";
            this.Text = "FrmBaoCao";
            this.Load += new System.EventHandler(this.FrmBaoCao_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptBaoCao;
        private System.Windows.Forms.ComboBox cboNXB;
        private System.Windows.Forms.Label label2;
    }
}