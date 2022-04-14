using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassDAL
{
    public class ThaoTac_CoSoDuLieu
    {
        SqlConnection GetConnection;

        private void KetnoiCSDL()

        {
            GetConnection = new SqlConnection(@"Data Source=DESKTOP-7SP0KLN;Initial Catalog=TiemThuocXuanCuong;Integrated Security=True");
            GetConnection.Open();
        }
        private void NgatKetNoi()
        {
            GetConnection.Close();
            GetConnection.Dispose();
        }
        //phương thức thực thi Select dữ liệu
        public DataTable SQL_Laydulieu(string TenSP)
        {
            KetnoiCSDL();
            //thực thi lấy dữ liệu từ CSDL
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //ngắt kết nối
            NgatKetNoi();
            //trả về bảng chứa dữ liệu lấy được.
            return dt;
        }

        public DataTable SQL_LaydulieuLoaiHangHoa(string TenSP)
        {
            KetnoiCSDL();
            //thực thi lấy dữ liệu từ CSDL
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable LoaiHangHoa = new DataTable();
            da.Fill(LoaiHangHoa);
            //ngắt kết nối
            NgatKetNoi();
            //trả về bảng chứa dữ liệu lấy được.
            return LoaiHangHoa;
        }
        public DataTable SQL_LayMaNhanVien(string TenSP)
        {
            KetnoiCSDL();
            //thực thi lấy dữ liệu từ CSDL
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable manv = new DataTable();
            da.Fill(manv);
            //ngắt kết nối
            NgatKetNoi();
            //trả về bảng chứa dữ liệu lấy được.
            return manv;
        }
        public DataTable SQL_Laydulieu_CoDK(string TenSP, string[] name, object[] value, int Npara)
        {
            KetnoiCSDL();
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Npara; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            NgatKetNoi();
            // Trả về bảng chứa dữ liệu lấy được
            return dt;
        }
        //phương thức thực thi Insert, Update, Delete
        public int SQL_Thuchien(string TenSP, string[] name, object[] value, int Npara)
        {
            KetnoiCSDL();
            SqlCommand cmd = new SqlCommand(TenSP, GetConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Npara; i++)
            {
                cmd.Parameters.AddWithValue(name[i], value[i]);
            }
            return cmd.ExecuteNonQuery();
        }
    }
}
