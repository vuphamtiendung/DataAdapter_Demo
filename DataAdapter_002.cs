using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ExerciseADO_002
{
    internal class DataAdapter_002
    {
        public void DataAdapter()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select_SinhVien", conn);
                // chọn loại StoreProcedure dùng để gọi thủ tục từ SQL
                da.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                // Sử dụng DataTable để lấy dữ liệu
                DataTable dt = new DataTable();
                // Điền vào table tương ứng
                da.Fill(dt);
                // Duyệt dữ liệu
                foreach(DataRow select in dt.Rows)
                {
                    WriteLine(select["MaSV"] + " | " + select["HoTen"] + " | " + select["MaLop"] + " | " + select["GioiTinh"] + " | " + select["NgaySinh"]);
                }

            }
            catch(Exception ex)
            {
                WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
