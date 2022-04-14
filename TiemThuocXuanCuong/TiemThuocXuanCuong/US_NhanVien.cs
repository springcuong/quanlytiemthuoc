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
    public partial class US_NhanVien : UserControl
    {
        public US_NhanVien()
        {
            InitializeComponent();
        }
        NhanVien_BLL nhanVien = new NhanVien_BLL();
        string Chuoiketnoi = @"Data Source=DESKTOP-1HJOTA3\SPRINGCUONG;Initial Catalog=TiemThuocXuanCuong;Integrated Security=True";
        string CauLenhSQL = null;
        SqlConnection SQLConnection;
        SqlDataAdapter SQLadapter;

        DataTable manv;
        private void US_NhanVien_Load(object sender, EventArgs e)
        {
            HamLayDanhSachNhanVien();
            manv = new DataTable();
        }
        public void HamLayDanhSachNhanVien()
        {
            dtgDanhSachNhanVien.DataSource=nhanVien.LayDanhSachNhanVien();
        }

        public void HamLayDanhSachTaiKhoan()
        {
            dtgDanhSachTaiKhoan.DataSource=nhanVien.LayDanhSachTaiKhoan(int.Parse(txtMaNhanVien.Text));
        }

        public void HamLayMaNhanVien()
        {
            SQLConnection = new SqlConnection(Chuoiketnoi);
            CauLenhSQL = "Select MAX(MaNV) as [Mã nhân viên] from NhanVien";
            SQLadapter = new SqlDataAdapter(CauLenhSQL, SQLConnection);
            SQLadapter.Fill(manv);
            SQLConnection.Close();
            SQLConnection.Dispose();

            foreach(DataRow dataRow in manv.Rows)
            {
                txtMaNhanVien.Text = dataRow[0].ToString();
            }
        }
        public void HamChuyenDuLieuSangTextBoxTaiKhoan()
        {
            foreach(DataGridViewRow row in dtgDanhSachTaiKhoan.Rows)
            {
                txtMaTaiKhoan.Text = row.Cells[0].Value.ToString();
                txtTaiKhoan.Text = row.Cells[2].Value.ToString();
                txtMatKhau.Text = row.Cells[3].Value.ToString();
            }
        }

        public void HamThemNhanVienVaTaiKhoan()
        {
            nhanVien.ThemNhanVien(txtTenNhanVien.Text, cboChucVu.Text, txtEmail.Text);
            HamLayMaNhanVien();         
            nhanVien.ThemTaiKhoan(int.Parse(txtMaNhanVien.Text),txtTaiKhoan.Text,txtMatKhau.Text,txtEmail.Text);
            HamLayDanhSachNhanVien();
            HamLayDanhSachTaiKhoan();
            HamChuyenDuLieuSangTextBoxTaiKhoan();
        }

        public void HamSuaTaiKhoanvaNhanVien()
        {
            nhanVien.SuaNhanVien(int.Parse(txtMaNhanVien.Text), txtTenNhanVien.Text, cboChucVu.Text, txtEmail.Text);
            nhanVien.SuaTaiKhoan(int.Parse(txtMaNhanVien.Text), txtTaiKhoan.Text, txtMatKhau.Text, txtEmail.Text);
            HamLayDanhSachNhanVien();
            HamLayDanhSachTaiKhoan();
        }
        private void dtgDanhSachNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = this.dtgDanhSachNhanVien.Rows[e.RowIndex];
            txtMaNhanVien.Text = row.Cells[0].Value.ToString();
            txtTenNhanVien.Text = row.Cells[1].Value.ToString();
            cboChucVu.Text = row.Cells[2].Value.ToString();
            txtEmail.Text = row.Cells[3].Value.ToString();
            HamLayDanhSachTaiKhoan();
            HamChuyenDuLieuSangTextBoxTaiKhoan();
        }

        private void dtgDanhSachTaiKhoan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = this.dtgDanhSachTaiKhoan.Rows[e.RowIndex];
            txtMaTaiKhoan.Text=row.Cells[0].Value.ToString();
            txtTaiKhoan.Text = row.Cells[2].Value.ToString();
            txtMatKhau.Text = row.Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HamThemNhanVienVaTaiKhoan();
        }
    }
}
