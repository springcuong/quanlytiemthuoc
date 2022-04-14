using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassDAL
{
    public class HangHoa_DAL
    {
        ThaoTac_CoSoDuLieu thaotac = new ThaoTac_CoSoDuLieu();
        string[] name = { };
        object[] value = { };
        public DataTable LayDanhSachSanPham()
        {
            name = new string[0];
            value = new object[0];
            return thaotac.SQL_Laydulieu_CoDK("LayDanhSachSanPham", name, value, 0);
        }
        public int ThemHangHoa(string LoaiHH, string TenHH, string DonViTinh, float GiaNhap, float GiaBan, int SoLuong)
        {
            name = new string[6];
            value = new object[6];
            name[0] = "@LoaiHH"; value[0] = LoaiHH;
            name[1] = "@TenHH"; value[1] = TenHH;
            name[2] = "@DonViTinh"; value[2] = DonViTinh;
            name[3] = "@GiaNhap"; value[3] = GiaNhap;
            name[4] = "@GiaBan"; value[4]= GiaBan;
            name[5] = "@SoLuong"; value[5] = SoLuong;
            return thaotac.SQL_Thuchien("ThemHangHoa", name, value, 6);
        }
        public int SuaHangHoa(int MaHH,string LoaiHH, string TenHH, string DonViTinh, float GiaNhap, float GiaBan, int SoLuong)
        {
            name = new string[7];
            value = new object[7];
            name[0] = "@MaHH"; value[0] = MaHH;
            name[1] = "@LoaiHH"; value[1] = LoaiHH;
            name[2] = "@TenHH"; value[2] = TenHH;
            name[3] = "@DonViTinh"; value[3] = DonViTinh;
            name[4] = "@GiaNhap"; value[4] = GiaNhap;
            name[5] = "@GiaBan"; value[5] = GiaBan;
            name[6] = "@SoLuong"; value[6] = SoLuong;
            return thaotac.SQL_Thuchien("SuaHangHoa", name, value, 7);
        }
        public int XoaHangHoa(int MaHH)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHH"; value[0] = MaHH;
            return thaotac.SQL_Thuchien("XoaHangHoa", name, value, 1);
        }
    }
}
