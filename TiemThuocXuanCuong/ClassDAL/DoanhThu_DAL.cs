using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClassDAL
{
    public class DoanhThu_DAL
    {
        ThaoTac_CoSoDuLieu thaotac = new ThaoTac_CoSoDuLieu();
        string[] name = { };
        object[] value = { };
        public DataTable LayDanhSachSanPham(DateTime NgayBatDau,DateTime NgayKetThuc)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@NgayBatDau"; value[0] = NgayBatDau;
            name[1] = "@NgayKetThuc"; value[1] = NgayKetThuc;
            return thaotac.SQL_Laydulieu_CoDK("LayDanhSachHoaDonTongKetDoanhThu", name, value, 2);
        }
    }
}
