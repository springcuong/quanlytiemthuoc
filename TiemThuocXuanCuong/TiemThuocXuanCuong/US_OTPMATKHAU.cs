using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.IO;
using ClassBLL;

namespace TiemThuocXuanCuong
{
    public partial class US_OTPMATKHAU : UserControl
    {
        public US_OTPMATKHAU()
        {
            InitializeComponent();
        }

        private void US_OTPMATKHAU_Load(object sender, EventArgs e)
        {
            txtMatKhauMoi.Visible = false;
            txtNhapLaiMatKhau.Visible = false;
            btnXacNhanThayDoiMatKhau.Visible = false;
        }
        public static DataTable dataTable;
        LayLaiMatKhau_BLL layLaiMatKhau = new LayLaiMatKhau_BLL();
        int OTP;
        public void LayMaOTP()
        {
            dataTable = layLaiMatKhau.LayMaOTP(txtTaiKhoan.Text, txtDiaChiEmail.Text);
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Nhập sai tài khoản hoặc gmail, vui lòng nhập lại");
                txtTaiKhoan.Focus();
            }
            else
            {
                MailMessage mm = new MailMessage("charan3k@gmail.com", txtDiaChiEmail.Text);
                Random rd = new Random();
                OTP = rd.Next(1, 6000);
                mm.Subject = "Lấy lại mật khẩu - Tiệm thuốc Xuân Cường";
                mm.Body = "Mã OTP của bạn là:" + OTP.ToString();
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                System.Net.NetworkCredential nc = new NetworkCredential("tiemthuocxuancuong@gmail.com", "tiemthuocbadao");
                smtp.EnableSsl = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
                MessageBox.Show("Đã gửi mã OTP đến mail thành công");
            }
        }
        public void XacNhan()
        {
            if (txtOTP.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã OTP");
                txtOTP.Focus();
            }
            else
            {
                if (string.Compare(txtOTP.Text, OTP.ToString()) == 0)
                {
                    BackgroundImage = Properties.Resources.frmthaydoimatkhau;
                    txtTaiKhoan.Visible = false;
                    txtOTP.Visible = false;
                    txtDiaChiEmail.Visible = false;
                    btnLayOTP.Visible = false;
                    btnXacNhan.Visible = false;
                    txtMatKhauMoi.Visible = true;
                    txtNhapLaiMatKhau.Visible = true;
                    btnXacNhanThayDoiMatKhau.Visible = true;
                }
                else
                {
                    MessageBox.Show("Mã OTP sai, vui lòng nhập lại");
                }
            }
        }
        public void XacNhanDoiMatKhau()
        {
            foreach (DataRow row in dataTable.Rows)
            {
                string taikhoan = row["TaiKhoan"].ToString();
                if (txtMatKhauMoi.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu mới");
                    txtMatKhauMoi.Text = "";
                    txtNhapLaiMatKhau.Text = "";
                    txtMatKhauMoi.Focus();
                }
                if (txtNhapLaiMatKhau.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập lại mật khẩu");
                    txtNhapLaiMatKhau.Text = "";
                    txtNhapLaiMatKhau.Focus();
                }
                else
                {
                    if (string.Compare(txtMatKhauMoi.Text, txtNhapLaiMatKhau.Text) == 0)
                    {
                        layLaiMatKhau.LayLaiMatKhau(taikhoan, txtMatKhauMoi.Text);
                        MessageBox.Show("Đã đổi mật khẩu thành công");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập trùng mật khẩu vừa nhập");
                    }
                }
            }
        }
        private void btnLayOTP_Click(object sender, EventArgs e)
        {
            LayMaOTP();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            XacNhan();
        }

        private void btnXacNhanThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            XacNhanDoiMatKhau();
        }
    }
}
