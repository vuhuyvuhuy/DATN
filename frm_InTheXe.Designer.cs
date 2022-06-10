namespace QL_GiuXe
{
    partial class frm_InTheXe
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnInThe = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 98);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1089, 327);
            this.reportViewer1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewer1);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(5, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1089, 425);
            this.panel2.TabIndex = 28;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.btnInThe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Blue;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1089, 98);
            this.panel1.TabIndex = 22;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Blue;
            this.Label1.Location = new System.Drawing.Point(466, 62);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(343, 19);
            this.Label1.TabIndex = 113;
            this.Label1.Text = "Lưu ý : Chỉ in thẻ khi thẻ đang trong tình trạng đang chờ";
            // 
            // btnInThe
            // 
            this.btnInThe.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnInThe.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInThe.ForeColor = System.Drawing.Color.Blue;
            this.btnInThe.Image = global::QL_GiuXe.Properties.Resources.print;
            this.btnInThe.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInThe.Location = new System.Drawing.Point(555, 12);
            this.btnInThe.Name = "btnInThe";
            this.btnInThe.Size = new System.Drawing.Size(146, 37);
            this.btnInThe.TabIndex = 5;
            this.btnInThe.Text = "In danh sách";
            this.btnInThe.UseVisualStyleBackColor = false;
            this.btnInThe.Click += new System.EventHandler(this.btnInThe_Click_1);
            // 
            // frm_InTheXe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 428);
            this.Controls.Add(this.panel2);
            this.Name = "frm_InTheXe";
            this.Text = "frm_InTheXe";
            this.Load += new System.EventHandler(this.frm_InTheXe_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnInThe;

    }
}