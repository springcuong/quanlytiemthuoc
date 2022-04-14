using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassDAL
{
    public class DatHang_DAL
    {
        ThaoTac_CoSoDuLieu thaotac = new ThaoTac_CoSoDuLieu();
        string[] name = { };
        object[] value = { };
        public DataTable LayDanhSachSanPham()
        {
            name = new string[0];
            value = new object[0];
            return thaotac.SQL_Laydulieu("LayDanhSachSanPhamDatHang");
        }
        public DataTable LayDanhSachSanPhamTheoLoaiHH(string LoaiHH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@LoaiHH";value[0]=LoaiHH;
            return thaotac.SQL_Laydulieu_CoDK("LayDachSachSanPhamTheoLoaiSanPham", name,value,1);
        }

        public DataTable LayDanhSachHoaDon()
        {
            name = new string[0];
            value = new object[0];
            return thaotac.SQL_Laydulieu("LayDanhSachHoaDon");
        }

        public DataTable LayDanhSachSanPhamTheoTextBox(string TenHH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@TenHH"; value[0] = TenHH;
            return thaotac.SQL_Laydulieu_CoDK("LayDachSachSanPhamTheoTextBox", name, value, 1);
        }
        public DataTable LayLoaiSanPham()
        {
            name = new string[0];
            value = new object[0];
            return thaotac.SQL_LaydulieuLoaiHangHoa("LayLoaiSanPham");
        }
        public int ThemChiTietHoaDon(int MaHD, int MaHH,int SoLuong)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@MaHH"; value[1] = MaHH;
            name[2] = "@SoLuong"; value[2] = SoLuong;
            return thaotac.SQL_Thuchien("ThemChiTietHoaDon", name, value, 3);
        }

        public int ThemHoaDon(string TenKH,string SDT,string TrieuChung,string LoiDan,DateTime NgayMuaHang)
        {
            name = new string[5];
            value = new object[5];
            name[0] = "@TenKH";value[0] = TenKH;
            name[1] = "@SDT"; value[1] = SDT;
            name[2] = "@TrieuChung"; value[2] = TrieuChung;
            name[3] = "@LoiDan"; value[3] = LoiDan;
            name[4] = "@NgayMuaHang"; value[4] = NgayMuaHang;
            return thaotac.SQL_Thuchien("ThemHoaDon", name, value, 5);
        }

        public int XoaHoaDon(int MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            return thaotac.SQL_Thuchien("XoaHoaDon", name, value, 1);
        }

        public int HamXoaToanBoChiTietHoaDon(int MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            return thaotac.SQL_Thuchien("XoaChiTietHoaDon", name, value, 1);
        }
        public int SuaThongTinChiTietHoaDon(int MaHD, int MaHH,int SoLuong)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@MaHH"; value[1] = MaHH;
            name[2] = "@SoLuong"; value[2] = SoLuong;
            return thaotac.SQL_Thuchien("SuaThongTinChiTietHoaDon", name, value, 3);
        }
        public int SuaSoLuongChiTietHoaDon(int MaHD, int MaHH, int SoLuong)
        {
            name = new string[3];
            value = new object[3];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@MaHH"; value[1] = MaHH;
            name[2] = "@SoLuong"; value[2] = SoLuong;
            return thaotac.SQL_Thuchien("SuaSoLuongChiTietHoaDon", name, value, 3);
        }

        public int XoaChiTietHoaDon(int MaHD, int MaHH)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@MaHH"; value[1] = MaHH;
            return thaotac.SQL_Thuchien("XoaThongTinChiTietHoaDon", name, value, 2);
        }

        public int ThanhToanHoaDon(int MaHD, float TongHD)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@TongHD"; value[1] = TongHD;
            return thaotac.SQL_Thuchien("ThanhToanHoaDon", name, value, 2);
        }
        public DataTable HienThiChiTietHoaDatHang(int MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD";value[0] = MaHD;
            return thaotac.SQL_Laydulieu_CoDK("HienThiChiTietHoaDatHang", name, value, 1);
        }
    }
}
