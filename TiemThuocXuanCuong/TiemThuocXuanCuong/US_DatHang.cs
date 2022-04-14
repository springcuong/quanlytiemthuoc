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
using System.Data.SqlClient;

namespace TiemThuocXuanCuong
{
    public partial class US_DatHang : UserControl
    {
        public US_DatHang()
        {
            InitializeComponent();
        }
        public static int MaHD;
        int index;
        DatHang_BLL datHang = new DatHang_BLL();
        bool trangthaitaohoadon = false;
        private void US_DatHang_Load(object sender, EventArgs e)
        {
            LayDanhSachSanPhamDatHang();
            LayLoaiHangHoa();
            LayDanhSachHoaDon();
        }

        public void LayDanhSachSanPhamDatHang()
        {
            dtgDanhSachSanPham.DataSource = datHang.LayDanhSachSanPhamDatHang();
        }
        public void LayDanhSachHoaDon()
        {
            dtgDanhSachHoaDon.DataSource = datHang.LayDanhSachHoaDon();
        }
        public void LayLoaiHangHoa()
        {
            cboLoaiSanPham.DataSource = datHang.LayLoaiSanPham();
            cboLoaiSanPham.DisplayMember = "LoaiHH";
        }
        public void HamLayDanhSachSanPhamTheoLoaiHH()
        {
            dtgDanhSachSanPham.DataSource = null;
            dtgDanhSachSanPham.DataSource = datHang.LayDanhSachSanPhamTheoLoaiHH(cboLoaiSanPham.Text);
        }
        public void HamLayDanhSachSanPhamTheoTextBox()
        {
            dtgDanhSachSanPham.DataSource = null;
            dtgDanhSachSanPham.DataSource = datHang.LayDanhSachSanPhamTheoTextBox(txtTimKiem.Text);
        }
        public void HamHienThiChietHoaDon()
        {
            double TongTien = 0;
            dtgChiTietHoaDon.DataSource = datHang.HienThiChiTietHoaDonDatHang(MaHD);
            foreach (DataGridViewRow dr in dtgChiTietHoaDon.Rows)
            {
                TongTien += double.Parse(dr.Cells[5].Value.ToString());
            }
            txtTongTien.Text = TongTien.ToString();
        }
        public void GetMaHoaDon()
        {
            MaHD = -1;
            foreach(DataGridViewRow row in dtgDanhSachHoaDon.Rows)
            {
                if(int.Parse(row.Cells[0].Value.ToString())>MaHD)
                {
                    MaHD = int.Parse(row.Cells[0].Value.ToString());
                }
            }
        }
        public void HamThemHoaDon()
        {
            DateTime dateTime = DateTime.Now;
            var shortdate = dateTime.ToString("yyyy-MM-dd");
            datHang.ThemHoaDon(txtTenKhachHang.Text, txtSDT.Text, txtTrieuChung.Text, txtLoiDan.Text, DateTime.Parse(shortdate));
            LayDanhSachHoaDon();
        }
        public void HamXoaHoaDon()
        {
            datHang.XoaHoaDon(MaHD);
            datHang.HamXoaToanBoChiTietHoaDon(MaHD);
            LayDanhSachHoaDon();
        }
        public void HamThemChiTietHoaDon()
        {
            DataGridViewRow row = this.dtgDanhSachSanPham.Rows[index];
            int MaHH = int.Parse(row.Cells[0].Value.ToString());
            int SoLuong = int.Parse(nupSoLuong.Value.ToString());
            string TenHH = row.Cells[1].Value.ToString();
            foreach (DataGridViewRow dr in dtgChiTietHoaDon.Rows)
            {
                string tenhhss = dr.Cells[1].Value.ToString();
                if (string.Compare(TenHH, tenhhss) == 0)
                {
                    int SoLuongMoi = int.Parse(dr.Cells[4].Value.ToString()) + SoLuong;
                    datHang.SuaThongThongTinChiTietHoaDon(MaHD, MaHH, SoLuongMoi);
                    return;
                }
            }
            datHang.ThemChiTietHoaDon(MaHD, MaHH, SoLuong);
        }
        public void HamSuaSoLuong()
        {
            DataGridViewRow row = this.dtgChiTietHoaDon.Rows[index];
            int MaHH = int.Parse(row.Cells[0].Value.ToString());
            int SoLuongMoi = int.Parse(nupSoLuong.Value.ToString());
            datHang.SuaSoLuongThongTinChiTietHoaDon(MaHD, MaHH, SoLuongMoi);
            HamHienThiChietHoaDon();
        }

        public void HamXoaChiTietHoaDon()
        {
            try
            {
                DataGridViewRow row = this.dtgChiTietHoaDon.Rows[index];
                int MaHH = int.Parse(row.Cells[0].Value.ToString());
                datHang.XoaChiTietHoaDon(MaHD, MaHH);
                HamHienThiChietHoaDon();
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi chọn giá trị");
            }
        }
        public void HamThemChietHoaDonVaHoaDon()
        {
            if(trangthaitaohoadon==false)
            {
                HamThemHoaDon();
                GetMaHoaDon();
                HamThemChiTietHoaDon();
                trangthaitaohoadon=true;
                HamHienThiChietHoaDon();
                LayDanhSachHoaDon();
                return;
            }
            if(trangthaitaohoadon==true)
            {
                HamThemChiTietHoaDon();
                HamHienThiChietHoaDon();
            }
        }
        public void HamThanhToanHoaDon()
        {
            datHang.ThanhToanHoaDon(MaHD, float.Parse(txtTongTien.Text.ToString()));
            trangthaitaohoadon = false;
            dtgChiTietHoaDon.DataSource = null;
            txtTongTien.Text = "";
            txtTenKhachHang.Text = "";
            txtSDT.Text = "";
            txtTrieuChung.Text = "";
            txtLoiDan.Text = "";
            LayDanhSachHoaDon();
        }

        private void dtgDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                DataGridViewRow row = this.dtgDanhSachSanPham.Rows[e.RowIndex];
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi chọn sản phẩm");
            }
        }

        private void dtgDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                DataGridViewRow row = this.dtgDanhSachSanPham.Rows[e.RowIndex];
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi chọn sản phẩm");
            }

        }

        private void dtgChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                index = e.RowIndex;
                DataGridViewRow row = this.dtgChiTietHoaDon.Rows[e.RowIndex];
                nupSoLuong.Value = int.Parse(row.Cells[4].Value.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi chọn sản phẩm");
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            HamThemChietHoaDonVaHoaDon();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            HamSuaSoLuong();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá sản phẩm?", "Cảnh báo!!!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HamXoaChiTietHoaDon();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }        
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thanh toán hoá đơn?", "Cảnh báo!!!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HamThanhToanHoaDon();
                DialogResult dialogResults = MessageBox.Show("Bạn có muốn in hoá đơn?", "Cảnh báo!!!!!", MessageBoxButtons.YesNo);
                {
                    if (dialogResults == DialogResult.Yes)
                    {
                        XuatHoaDon frm = new XuatHoaDon();
                        frm.Show();
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }

        }
        private void cboLoaiSanPham_Click(object sender, EventArgs e)
        {
            HamLayDanhSachSanPhamTheoLoaiHH();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            HamLayDanhSachSanPhamTheoTextBox();
        }

        private void dtgDanhSachSanPham_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HamThemChietHoaDonVaHoaDon();
        }

        private void nupSoLuong_MouseDown(object sender, MouseEventArgs e)
        {
            //HamSuaSoLuong();
        }

        private void nupSoLuong_MouseUp(object sender, MouseEventArgs e)
        {
            //HamSuaSoLuong();
        }

        private void dtgChiTietHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            HamXoaChiTietHoaDon();
        }

        private void dtgDanhSachHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                DataGridViewRow row = this.dtgDanhSachHoaDon.Rows[e.RowIndex];
                MaHD = int.Parse(row.Cells[0].Value.ToString());
                HamHienThiChietHoaDon();
                txtTenKhachHang.Text = row.Cells[1].Value.ToString();
                txtSDT.Text = row.Cells[2].Value.ToString();
                txtTrieuChung.Text = row.Cells[3].Value.ToString();
                txtLoiDan.Text = row.Cells[4].Value.ToString();
                trangthaitaohoadon = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Lỗi chọn hoá đơn");
            }
        }

        private void dtgDanhSachHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn xoá hoá đơn(Yes/No)", "Cảnh báo!!!!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                HamXoaHoaDon();
                trangthaitaohoadon = false;
                dtgChiTietHoaDon.DataSource = null;
                txtTongTien.Text = "";
                txtTenKhachHang.Text = "";
                txtSDT.Text = "";
                txtTrieuChung.Text = "";
                txtLoiDan.Text = "";
                LayDanhSachHoaDon();
            }
            else if (dialogResult == DialogResult.No)
            {
            }          
        }
    }
}
