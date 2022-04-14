using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using System.Data;
namespace ClassBLL
{
    public class HangHoa_BLL
    {
        HangHoa_DAL hangHoa = new HangHoa_DAL();

        public DataTable LayDanhSachSanPham()
        {
            return hangHoa.LayDanhSachSanPham();
        }

        public int ThemHangHoa(string LoaiHH, string TenHH, string DonViTinh, float GiaNhap, float GiaBan, int SoLuong)
        {
            return hangHoa.ThemHangHoa(LoaiHH, TenHH, DonViTinh, GiaNhap, GiaBan, SoLuong);
        }
        public int SuaHangHoa(int MaHH,string LoaiHH, string TenHH, string DonViTinh, float GiaNhap, float GiaBan, int SoLuong)
        {
            return hangHoa.SuaHangHoa(MaHH, LoaiHH, TenHH, DonViTinh, GiaNhap, GiaBan, SoLuong);
        }
        public int XoaHangHoa(int MaHH)
        {
            return hangHoa.XoaHangHoa(MaHH);
        }
    }
}
