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
    internal class DataAdapter_003
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
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable(); // Sử dụng DataTable để lấy dữ liệu
                da.Fill(dt); // Điền vào DataSet với các trường tương ứng
                // Duyệt dữ liệu
                foreach (DataRow select in dt.Rows)
                {
                    WriteLine(select["MaSV"] + " | " + select["HoTen"] + " | " + select["GioiTinh"] + " | " + select["NgaySinh"]);
                }
            }
            catch(Exception ex)
            {
                WriteLine("Đã có lỗi xảy ra " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
