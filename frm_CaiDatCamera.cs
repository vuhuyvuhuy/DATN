using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;

namespace QL_GiuXe
{
    public partial class frm_CaiDatCamera : Form
    {
        public frm_CaiDatCamera()
        {
            InitializeComponent();
        }
        public static void writefile2(string Truoc, string Sau)
        {
            string fileName = Application.StartupPath + "Confix";

            if (File.Exists(fileName) == false) // n
            {
                const String filepath = "Confix";// đường dẫn của file muốn tạo
                FileStream tao = new FileStream(filepath, FileMode.Create);
                StreamWriter write = new StreamWriter(tao, Encoding.UTF8);

                write.WriteLine("SV=:" + Truoc);
                write.WriteLine("DB=:" + Sau);

                write.Close();
            }
            else
            {
                StreamWriter write = new StreamWriter("Confix");
                write.WriteLine("SV=:" + Truoc);
                write.WriteLine("DB=:" + Sau);
                write.Close();
            }

        }
        FilterInfoCollection videoDevices;
        VideoCaptureDevice videoSource;
        private void frm_CaiDatCamera_Load(object sender, EventArgs e)
        {
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                cbtruoc.Items.Add(device.Name);
                cbsau.Items.Add(device.Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                writefile2(cbtruoc.Text, cbsau.Text);
                MessageBox.Show("Lưu Thành Công", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            }
            catch
            { }
        }
    }
}
