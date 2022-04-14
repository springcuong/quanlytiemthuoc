using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassDAL;

namespace ClassBLL
{
    public class DoanhThu_BLL
    {
        DoanhThu_DAL doanhThu = new DoanhThu_DAL();
        public DataTable LayDanhSachSanPham(DateTime NgayBatDau, DateTime NgayKetThuc)
        {
            return doanhThu.LayDanhSachSanPham(NgayBatDau,NgayKetThuc);
        }
    }
}
