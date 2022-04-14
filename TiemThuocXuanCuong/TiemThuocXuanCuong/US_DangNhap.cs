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
    public partial class US_DangNhap : UserControl
    {
        public US_DangNhap()
        {
            InitializeComponent();
        }
        DanhNhap_BLL danhNhap = new DanhNhap_BLL();
        Form1 frm1 = new Form1();
        private void US_DangNhap_Load(object sender, EventArgs e)
        {

        }
        public void DangNhap()
        {
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
                    frm1.ShowDialog();
                }
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            DangNhap();
        }

    }
}
