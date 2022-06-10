using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using DevComponents.DotNetBar;

namespace QL_GiuXe
{
    public partial class frm_InTheXe : Office2007RibbonForm
    {
        ConnectDB cn = new ConnectDB();
        DataTable dt;

        public frm_InTheXe()
        {
            InitializeComponent();
        }

        private void frm_InTheXe_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void btnInThe_Click(object sender, EventArgs e)
        {
           
            
        }

        private void btnInThe_Click_1(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.RefreshReport();

                string sql = @"SELECT SOTHE FROM THE WHERE Tinhtrang =N'Đang chờ cấp'";


                reportViewer1.Reset();
                dt = cn.taobang(sql);
                reportViewer1.LocalReport.ReportEmbeddedResource = "QL_GiuXe.rptInTheXe.rdlc";
                reportViewer1.LocalReport.DataSources.Clear();
                Microsoft.Reporting.WinForms.ReportDataSource newDataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Add(newDataSource);
                reportViewer1.RefreshReport();
                reportViewer1.LocalReport.DisplayName = "In thẻ mới";
                reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                reportViewer1.ZoomPercent = 50;
            }
            catch (Exception)
            {
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
