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
    internal class DataAdapter
    { 

        public void Adapter()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select_SinhVien", conn);
                // chọn loại Store Procedure dùng để gọi thủ tục từ SQL
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                // Sử dụng DataTable để lấy dữ liệu
                DataTable dt = new DataTable();
                // điền vào table với các trường tương tứng
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
