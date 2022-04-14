using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassDAL;

namespace ClassBLL
{
    public class LayLaiMatKhau_BLL
    {
        LayLaiMatKhau_DAL layLaiMatKhau = new LayLaiMatKhau_DAL();

        public DataTable LayMaOTP(string TaiKhoan, string Gmail)
        {
            return layLaiMatKhau.LayThongTinTaiKhoan(TaiKhoan, Gmail);
        }

        public int LayLaiMatKhau(string TaiKhoan, string MatKhau)
        {
            return layLaiMatKhau.UpDate_LayLaiMatKhau(TaiKhoan, MatKhau);
        }
    }
}
