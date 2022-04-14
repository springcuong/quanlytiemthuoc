using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ClassDAL;

namespace ClassBLL
{
    public class XuatHoaDonBLL
    {
        XuatHoaDonDAL xuatHoaDon = new XuatHoaDonDAL();

        public DataTable LayHoaDon(int MaHD)
        {
            return xuatHoaDon.LayHoaDon(MaHD);
        }
    }
}
