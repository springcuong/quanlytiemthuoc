using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using System.Data;

namespace ClassBLL
{
    public class DanhNhap_BLL
    {
        DangNhap_DAL dangNhap = new DangNhap_DAL();

        public DataTable DangNhap(string TaiKhoan, string MatKhau)
        {
            return dangNhap.DangNhap(TaiKhoan,MatKhau);
        }

        public int LayLaiMatKhau(string TaiKhoan, string MatKhau)
        {
            return dangNhap.UpDate_LayLaiMatKhau(TaiKhoan, MatKhau);
        }
    }
}
