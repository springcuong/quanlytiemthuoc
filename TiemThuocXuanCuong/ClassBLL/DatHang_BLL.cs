using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassDAL;

namespace ClassBLL
{
    public class DatHang_BLL
    {
        DatHang_DAL datHang = new DatHang_DAL();
        public DataTable LayDanhSachSanPhamDatHang()
        {
            return datHang.LayDanhSachSanPham();
        }
        public DataTable LayDanhSachHoaDon()
        {
            return datHang.LayDanhSachHoaDon();
        }
        public DataTable HienThiChiTietHoaDonDatHang(int MaHD)
        {
            return datHang.HienThiChiTietHoaDatHang(MaHD);
        }
        public DataTable LayLoaiSanPham()
        {
            return datHang.LayLoaiSanPham();
        }
        public DataTable LayDanhSachSanPhamTheoLoaiHH(string LoaiHH)
        {
            return datHang.LayDanhSachSanPhamTheoLoaiHH(LoaiHH);
        }
        public DataTable LayDanhSachSanPhamTheoTextBox(string TenHH)
        {
            return datHang.LayDanhSachSanPhamTheoTextBox(TenHH);
        }
        public int ThemChiTietHoaDon(int MaHD, int MaHH, int SoLuong)
        {
            return datHang.ThemChiTietHoaDon(MaHD, MaHH,SoLuong);
        }

        public int ThemHoaDon(string TenKH, string SDT, string TrieuChung, string LoiDan, DateTime NgayMuaHang)
        {
            return datHang.ThemHoaDon(TenKH, SDT, TrieuChung, LoiDan, NgayMuaHang);
        }
        public int XoaHoaDon(int MaHD)
        {
            return datHang.XoaHoaDon(MaHD);
        }
        public int HamXoaToanBoChiTietHoaDon(int MaHD)
        {
            return datHang.HamXoaToanBoChiTietHoaDon(MaHD);
        }
        public int SuaThongThongTinChiTietHoaDon(int MaHD, int MaHH, int SoLuong)
        {
            return datHang.SuaThongTinChiTietHoaDon(MaHD, MaHH, SoLuong);
        }

        public int SuaSoLuongThongTinChiTietHoaDon(int MaHD, int MaHH, int SoLuong)
        {
            return datHang.SuaSoLuongChiTietHoaDon(MaHD, MaHH, SoLuong);
        }

        public int XoaChiTietHoaDon(int MaHD, int MaHH)
        {
            return datHang.XoaChiTietHoaDon(MaHD, MaHH);
        }

        public int ThanhToanHoaDon(int MaHD, float TongHD)
        {
            return datHang.ThanhToanHoaDon(MaHD, TongHD);
        }
    }
}
