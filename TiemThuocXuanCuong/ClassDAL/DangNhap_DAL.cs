using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassDAL
{
    public class DangNhap_DAL
    {
        ThaoTac_CoSoDuLieu thaotac = new ThaoTac_CoSoDuLieu();
        string[] name = { };
        object[] value = { };
        public DataTable DangNhap(string TaiKhoan, string MatKhau)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@TaiKhoan"; value[0] = TaiKhoan;
            name[1] = "@MatKhau"; value[1] = MatKhau;
            return thaotac.SQL_Laydulieu_CoDK("DangNhapVaoHeThong", name, value, 2);
        }
        public int UpDate_LayLaiMatKhau(string TaiKhoan,string MatKhau)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@TaiKhoan"; value[0] = TaiKhoan;
            name[1] = "@MatKhau"; value[1] = MatKhau;
            return thaotac.SQL_Thuchien("LayLaiMatKhau", name, value, 2);
        }
    }
}
