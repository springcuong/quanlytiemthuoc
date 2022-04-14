using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassDAL;
using System.Data;

namespace ClassBLL
{
    public class ThongKeBLL
    {
        ThongKeDAL thongKe = new ThongKeDAL();
        public DataTable LayDanhSachSanPhamBanChayNhat(DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            return thongKe.LayDanhSachSanPhamBanChay(NgayBatDau, NgayKetThuc);
        }
        public DataTable LayDanhSachSanPhamBanChamNhat(DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            return thongKe.LayDanhSachSanPhamBanCham(NgayBatDau, NgayKetThuc);
        }
    }
}
