using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiemThuocXuanCuong
{
    public partial class QuenMatKhau : Form
    {
        public QuenMatKhau()
        {
            InitializeComponent();
        }
        US_OTPMATKHAU uS_OTPMATKHAU = new US_OTPMATKHAU();
        private void QuenMatKhau_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(uS_OTPMATKHAU);
            uS_OTPMATKHAU.Show();
        }
    }
}
