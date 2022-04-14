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
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        DanhNhap_BLL danhNhap = new DanhNhap_BLL();
        public void HamDangNhap()
        {
            Form1 frm1 = new Form1();
            if (txtTaiKhoan.Text == "" || txtMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!");
            }
            else
            {
                DataTable dt = danhNhap.DangNhap(txtTaiKhoan.Text, txtMatKhau.Text);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Sai tài khoản và mật khẩu!");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công!!");
                    this.Hide();
                    frm1.ShowDialog();
                    this.Show();
                }
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            HamDangNhap();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
        }

        private void btnQuenMatKhau_Click(object sender, EventArgs e)
        {
            QuenMatKhau quenMatKhau = new QuenMatKhau();
            quenMatKhau.ShowDialog();
        }
    }
}
