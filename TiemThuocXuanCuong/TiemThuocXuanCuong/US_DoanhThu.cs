using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassBLL;
using System.Net;
using System.Net.Mail;
using System.IO;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using CrystalDecisions.Shared;
namespace TiemThuocXuanCuong
{
    public partial class US_DoanhThu : UserControl
    {
        public US_DoanhThu()
        {
            InitializeComponent();
        }
        DoanhThu_BLL doanhThu = new DoanhThu_BLL();
        string TieuDe;
        string TenFile;
        private void US_DoanhThu_Load(object sender, EventArgs e)
        {
            var shortdate1 = DateTime.Now.ToString("yyyy-MM-dd");
            var shortdate2 = DateTime.Now.ToString("yyyy-MM-dd");
            BaoCaoDoanhThu rpt = new BaoCaoDoanhThu();
            rpt.SetDataSource(doanhThu.LayDanhSachSanPham(DateTime.Parse(shortdate1), DateTime.Parse(shortdate2)));
            crystalReportViewer1.ReportSource = rpt;
            labelBaoCaDoanhThu.Text = "Báo cáo doanh thu từ ngày" + " "  + shortdate1.ToString() + " " + "đến ngày" + " " + shortdate2.ToString();
            TenFile ="Doanh thu từ ngày" +" "+ shortdate1 + " đến " + shortdate2;
            HamXuatReport(rpt);
        }

        public void LayDanhSachSanPham()
        {
            var shortdate1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var shortdate2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            BaoCaoDoanhThu rpt = new BaoCaoDoanhThu();
            rpt.SetDataSource(doanhThu.LayDanhSachSanPham(DateTime.Parse(shortdate1), DateTime.Parse(shortdate2)));
            crystalReportViewer1.ReportSource = rpt;
            labelBaoCaDoanhThu.Text = "Báo cáo doanh thu từ ngày" + " " + shortdate1.ToString() + " " + "đến ngày" + " " + shortdate2.ToString();
            TenFile = "Doanh thu từ ngày" + " " + shortdate1 + " đến " + shortdate2;
            HamXuatReport(rpt);
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            LayDanhSachSanPham();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            LayDanhSachSanPham();
        }
        public void HamXuatReport(BaoCaoDoanhThu rd)
        {
            String exportPath = @"D:\BAOCAODOANHTHU\";
            String tenfile = "" + TenFile + ".pdf";
            if (!System.IO.Directory.Exists(exportPath))
            {
                System.IO.Directory.CreateDirectory(exportPath);
            }
            rd.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath + tenfile);
        }
        public void HamGuiMail()
        {
            MailMessage mm = new MailMessage("charan3k@gmail.com", "trxuancuong150101@gmail.com");
            TieuDe = labelBaoCaDoanhThu.Text;
            mm.Subject = TieuDe;
            mm.Body = "Gửi sếp đẹp trai!";
            string filename = @"D:\BAOCAODOANHTHU\" + TenFile + ".pdf";
            mm.Attachments.Add(new Attachment(filename));
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            System.Net.NetworkCredential nc = new NetworkCredential("tiemthuocxuancuong@gmail.com", "tiemthuocbadao");
            smtp.EnableSsl = true;
            smtp.Credentials = nc;
            smtp.Send(mm);
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn gửi mail báo cáo doanh thu cho quản lý?", "Lưu ý!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HamGuiMail();
                MessageBox.Show("Đã xuất file report và gửi báo cáo doanh thu thành công!");
            }
            if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Đã xuất file report thành công!");
            }
        }
    }
}
