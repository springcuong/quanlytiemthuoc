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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        US_DatHang datHang = new US_DatHang();
        US_HangHoa uS_HangHoa = new US_HangHoa();
        US_NhanVien uS_NhanVien = new US_NhanVien();
        US_DoanhThu uS_DoanhThu = new US_DoanhThu();
        private void Form1_Load(object sender, EventArgs e)
        {
            Location = new Point(
            (Location.X + Width / 2) - (Width / 2),
            (Location.Y + Height / 2) - (Height / 2));
            StartPosition = FormStartPosition.Manual;
            StartPosition = FormStartPosition.CenterParent;
            Size = new Size(1819, 947);
            panel1.Size = new Size(1800, 850);
            panel1.Controls.Clear();
            panel1.Controls.Add(datHang);
            datHang.Show();
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            Size = new Size(1819, 947);
            panel1.Size = new Size(1800, 850);
            panel1.Controls.Clear();
            panel1.Controls.Add(datHang);
            datHang.Show();
        }

        private void btnHangHoa_Click(object sender, EventArgs e)
        {
            Size = new Size(1421, 947);
            panel1.Size = new Size(1400, 850);
            panel1.Controls.Clear();
            panel1.Controls.Add(uS_HangHoa);
            uS_HangHoa.Show();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            Size = new Size(1421, 947);
            panel1.Size = new Size(1400, 850);
            panel1.Controls.Clear();
            panel1.Controls.Add(uS_NhanVien);
            uS_NhanVien.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            Size = new Size(1421, 947);
            panel1.Size = new Size(1400, 850);
            panel1.Controls.Clear();
            panel1.Controls.Add(uS_DoanhThu);
            uS_DoanhThu.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.Show();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe();
            tk.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Excel excel = new Excel();
            excel.ShowDialog();
        }
    }
}
