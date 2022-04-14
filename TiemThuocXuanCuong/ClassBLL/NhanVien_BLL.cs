using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using System.Data;
namespace ClassBLL
{
    public class NhanVien_BLL
    {
        NhanVien_DAL nhanVien = new NhanVien_DAL();

        public DataTable LayDanhSachNhanVien()
        {
            return nhanVien.LayDanhSachNhanVien();
        }

        public DataTable LayDanhSachTaiKhoan(int MaNV)
        {
            return nhanVien.LayDanhSachTaiKhoan(MaNV);
        }

        public DataTable LayMaNhanVien()
        {
            return nhanVien.LayMaNhanVien();
        }

        public int ThemNhanVien(string TenNV, string ChucVu, string Email)
        {
            return nhanVien.ThemNhanVien(TenNV, ChucVu, Email);
        }

        public int ThemTaiKhoan(int MaNV, string TaiKhoan, string MatKhau, string Email)
        {
            return nhanVien.ThemTaiKhoan(MaNV, TaiKhoan, MatKhau, Email);
        }

        public int SuaNhanVien(int MaNV, string TenNV, string ChucVu, string Email)
        {
            return nhanVien.SuaNhanVien(MaNV, TenNV, ChucVu, Email);
        }

        public int SuaTaiKhoan(int MaNV, string TaiKhoan, string MatKhau, string Email)
        {
            return nhanVien.SuaTaiKhoan(MaNV, TaiKhoan, MatKhau, Email);
        }
    }
}
