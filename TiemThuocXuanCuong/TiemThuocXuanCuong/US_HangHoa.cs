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
    public partial class US_HangHoa : UserControl
    {
        public US_HangHoa()
        {
            InitializeComponent();
        }
        HangHoa_BLL hangHoa = new HangHoa_BLL();
        private void US_HangHoa_Load(object sender, EventArgs e)
        {
            LayDuLieuHangHoa();
        }

        public void LayDuLieuHangHoa()
        {
            dtgDanhSachSanPham.DataSource = hangHoa.LayDanhSachSanPham();
        }
        public void XoaDauVao()
        {
            txtMaHangHoa.Text = "";
            cboLoaiHangHoa.SelectedIndex = 0;
            txtTenHangHoa.Text = "";
            cboDonViTinh.SelectedIndex = 0;
            nupGiaNhap.Value = 15000;
            nupGiaBan.Value = 15000;
            nupSoLuong.Value = 1;
        }
        public void HamThemHangHoa()
        {
            hangHoa.ThemHangHoa(cboLoaiHangHoa.Text, txtTenHangHoa.Text, cboDonViTinh.Text, float.Parse(nupGiaNhap.Value.ToString()), float.Parse(nupGiaBan.Value.ToString()), int.Parse(nupSoLuong.Value.ToString()));
            LayDuLieuHangHoa();
            XoaDauVao();
        }

        public void HamSuaHangHoa()
        {
            hangHoa.SuaHangHoa(int.Parse(txtMaHangHoa.Text),cboLoaiHangHoa.Text, txtTenHangHoa.Text, cboDonViTinh.Text, float.Parse(nupGiaNhap.Value.ToString()), float.Parse(nupGiaBan.Value.ToString()), int.Parse(nupSoLuong.Value.ToString()));
            LayDuLieuHangHoa();
            XoaDauVao();
        }
        public void HamXoaHangHoa()
        {
            hangHoa.XoaHangHoa(int.Parse(txtMaHangHoa.Text));
            LayDuLieuHangHoa();
            XoaDauVao();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HamThemHangHoa();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            HamSuaHangHoa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            HamXoaHangHoa();
        }

        private void dtgDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = this.dtgDanhSachSanPham.Rows[e.RowIndex];
            txtMaHangHoa.Text = row.Cells[0].Value.ToString();
            txtTenHangHoa.Text = row.Cells[1].Value.ToString();
            cboLoaiHangHoa.Text = row.Cells[2].Value.ToString();
            cboDonViTinh.Text = row.Cells[3].Value.ToString();
            nupGiaNhap.Value = decimal.Parse(row.Cells[4].Value.ToString());
            nupGiaBan.Value = decimal.Parse(row.Cells[5].Value.ToString());
            nupSoLuong.Value = decimal.Parse(row.Cells[6].Value.ToString());
        }
    }
}
