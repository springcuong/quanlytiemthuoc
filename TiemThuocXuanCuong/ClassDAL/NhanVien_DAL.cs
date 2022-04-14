using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassDAL
{
    public class NhanVien_DAL
    {
        ThaoTac_CoSoDuLieu thaotac = new ThaoTac_CoSoDuLieu();
        string[] name = { };
        object[] value = { };

        public DataTable LayDanhSachNhanVien()
        {
            return thaotac.SQL_Laydulieu("LayDanhSachNhanVien");
        }

        public DataTable LayDanhSachTaiKhoan(int MaNV)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaNV"; value[0] = MaNV;
            return thaotac.SQL_Laydulieu_CoDK("LayDanhSachTaiKhoan", name,value,1);
        }
        public DataTable LayMaNhanVien()
        {
            return thaotac.SQL_LayMaNhanVien("LayMaNhanVien");
        }
        public int ThemNhanVien(string TenNV, string ChucVu, string Email)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@TenNV"; value[0] = TenNV;
            name[1] = "@ChucVu"; value[1] = ChucVu;
            name[2] = "@Email"; value[2] = Email;
            return thaotac.SQL_Thuchien("ThemNhanVien", name, value, 3);
        }
        public int ThemTaiKhoan(int MaNV, string TaiKhoan, string MatKhau, string Email)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@TaiKhoan"; value[1] = TaiKhoan;
            name[2] = "@MatKhau"; value[2] = MatKhau;
            name[3] = "@Email"; value[3] = Email;
            return thaotac.SQL_Thuchien("ThemTaiKhoan", name, value, 4);
        }
        public int SuaNhanVien(int MaNV, string TenNV, string ChucVu, string Email)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@TenNV"; value[1] = TenNV;
            name[2] = "@ChucVu"; value[2] = ChucVu;
            name[3] = "@Email"; value[3] = Email;
            return thaotac.SQL_Thuchien("SuaNhanVien", name, value, 4);
        }

        public int SuaTaiKhoan(int MaNV, string TaiKhoan, string MatKhau, string Email)
        {
            name = new string[4];
            value = new object[4];
            name[0] = "@MaNV"; value[0] = MaNV;
            name[1] = "@TaiKhoan"; value[1] = TaiKhoan;
            name[2] = "@MatKhau"; value[2] = MatKhau;
            name[3] = "@Email"; value[3] = Email;
            return thaotac.SQL_Thuchien("SuaTaiKhoan", name, value, 4);
        }
    }
}
