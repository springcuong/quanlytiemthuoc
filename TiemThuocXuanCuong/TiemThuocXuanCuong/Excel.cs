using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;

namespace TiemThuocXuanCuong
{
    public partial class Excel : Form
    {
        public Excel()
        {
            InitializeComponent();
        }
        string strfileName = @"D:\DanhSachSanPhamMois.xlsx";
        int index;
        private void Excel_Load(object sender, EventArgs e)
        {
            NhapExCel();
        }
        public void NhapExCel()
        {
            dtvQuanLySanPham.Rows.Clear();
            Microsoft.Office.Interop.Excel.Application xlApp;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlworkSheet;
            Microsoft.Office.Interop.Excel.Range xlRange;
            int xlRow;

            if (strfileName != string.Empty)
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strfileName);
                xlworkSheet = xlWorkBook.Worksheets["Sheet1"];
                xlRange = xlworkSheet.UsedRange;

                for (xlRow = 2; xlRow <= xlRange.Rows.Count; xlRow++)
                {
                    dtvQuanLySanPham.Rows.Add(xlRange.Cells[xlRow, 1].Text, xlRange.Cells[xlRow, 2].Text,
                    xlRange.Cells[xlRow, 3].Text, xlRange.Cells[xlRow, 4].Text, xlRange.Cells[xlRow, 5].Text
                    );
                }
                xlWorkBook.Close();
                xlApp.Quit();
            }
        }
        private void XuatExcelSanPham(DataGridView g, string duongDan, string tenTap)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(duongDan + tenTap + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            NhapExCel();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            XuatExcelSanPham(dtvQuanLySanPham, @"D:\", "DanhSachSanPhamMois");
        }

        private void dtvQuanLySanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            DataGridViewRow row = this.dtvQuanLySanPham.Rows[e.RowIndex];
            txtMaSanPham.Text = row.Cells[0].Value.ToString();
            txtTenSanPham.Text = row.Cells[1].Value.ToString();
            cboLoaiSanPham.Text = row.Cells[2].Value.ToString();
            cboDonViTinh.Text = row.Cells[3].Value.ToString();
            nupGiaBan.Value = decimal.Parse(row.Cells[4].Value.ToString());
        }
        public void HamLoadLai()
        {
            XuatExcelSanPham(dtvQuanLySanPham, @"D:\", "DanhSachSanPhamMois");
            NhapExCel();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            dtvQuanLySanPham.Rows.Add(txtMaSanPham.Text,txtTenSanPham.Text,cboLoaiSanPham.Text,cboDonViTinh.Text,nupGiaBan.Value);
            HamLoadLai();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.dtvQuanLySanPham.Rows[index];
            row.Cells[1].Value = txtTenSanPham.Text;
            row.Cells[2].Value = cboLoaiSanPham.Text;
            row.Cells[3].Value = cboDonViTinh.Text;
            row.Cells[4].Value = nupGiaBan.Value;
            HamLoadLai();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in dtvQuanLySanPham.SelectedCells)
            {
                if (oneCell.Selected)
                    dtvQuanLySanPham.Rows.RemoveAt(oneCell.RowIndex);
            }
            HamLoadLai();
        }
    }
}
