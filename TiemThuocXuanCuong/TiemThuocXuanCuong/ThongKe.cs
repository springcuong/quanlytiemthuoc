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

namespace TiemThuocXuanCuong
{
    public partial class ThongKe : Form
    {
        public ThongKe()
        {
            InitializeComponent();
        }
        ThongKeBLL thongKe = new ThongKeBLL();
        private void button1_Click(object sender, EventArgs e)
        {
            var shortdate1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var shortdate2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            if (rdbBanChay.Checked == true)
            {
                SanPhamBanChayNhat rpt = new SanPhamBanChayNhat();
                rpt.SetDataSource(thongKe.LayDanhSachSanPhamBanChayNhat(DateTime.Parse(shortdate1), DateTime.Parse(shortdate2)));
                crystalReportViewer1.ReportSource = rpt;
            }
            if(rdbBanCham.Checked==true)
            {
                SanPhamBanChamNhat rpt = new SanPhamBanChamNhat();
                rpt.SetDataSource(thongKe.LayDanhSachSanPhamBanChamNhat(DateTime.Parse(shortdate1), DateTime.Parse(shortdate2)));
                crystalReportViewer1.ReportSource = rpt;
            }
        }
        private void ThongKe_Load(object sender, EventArgs e)
        {
            var shortdate1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            var shortdate2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            SanPhamBanChamNhat rpt = new SanPhamBanChamNhat();
            rpt.SetDataSource(thongKe.LayDanhSachSanPhamBanChamNhat(DateTime.Parse(shortdate1), DateTime.Parse(shortdate2)));
            crystalReportViewer1.ReportSource = rpt;
        }
    }
}
