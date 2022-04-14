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
using CrystalDecisions.Shared;

namespace TiemThuocXuanCuong
{
    public partial class XuatHoaDon : Form
    {
        public XuatHoaDon()
        {
            InitializeComponent();
        }

        XuatHoaDonBLL xuatHoaDon = new XuatHoaDonBLL();

        private void XuatHoaDon_Load(object sender, EventArgs e)
        {
            //crystalReportViewer1.DisplayToolbar = false;
            //crystalReportViewer1.DisplayStatusBar = false;
            HoaDonBanHang rpt = new HoaDonBanHang();
            rpt.SetDataSource(xuatHoaDon.LayHoaDon(US_DatHang.MaHD));
            crystalReportViewer1.ReportSource = rpt;
            ExportToPDF_RD(rpt);
        }
        public static void ExportToPDF_RD(HoaDonBanHang rd)
        {
            String exportPath = @"D:\BAOCAODOANHTHU\";
            String tenfile = "" + US_DatHang.MaHD + ".pdf";
            if (!System.IO.Directory.Exists(exportPath))
            {
                System.IO.Directory.CreateDirectory(exportPath);
            }
            rd.ExportToDisk(ExportFormatType.PortableDocFormat, exportPath + tenfile);
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
