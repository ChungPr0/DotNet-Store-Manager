
using System.Data;
using System.Data.SqlClient;

namespace StoreManager.Utils
{
    public class DatabaseHelper
    {
        // 1. Đặt Connection String của bạn ở đây
        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StoreManager;Integrated Security=True";

        // Sử dụng pattern Singleton để dễ gọi hàm từ bất kỳ đâu mà không cần new nhiều lần
        private static DatabaseHelper instance;
        public static DatabaseHelper Instance
        {
            get { if (instance == null) instance = new DatabaseHelper(); return instance; }
            private set { instance = value; }
        }

        // Constructor private để cấm tạo object bừa bãi
        private DatabaseHelper() { }

        // ======================================================
        // HÀM 1: Dùng cho câu lệnh SELECT (Trả về 1 bảng dữ liệu)
        // ======================================================
        [Obsolete]
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            DataTable dataTable = new DataTable();

            // Khối using sẽ tự động đóng kết nối (Close) khi xong việc, rất an toàn
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Nếu có tham số truyền vào (để chống SQL Injection) thì add vào command
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    // SqlDataAdapter tự động Open connection, lấy data đổ vào DataTable rồi Close
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // ======================================================
        // HÀM 2: Dùng cho INSERT, UPDATE, DELETE (Trả về số dòng thành công)
        // ======================================================
        [Obsolete]
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    affectedRows = command.ExecuteNonQuery();
                }
            }
            return affectedRows;
        }

        // ======================================================
        // HÀM 3: Dùng cho SELECT COUNT, SUM, MAX... (Trả về 1 ô dữ liệu duy nhất)
        // ======================================================
        [Obsolete]
        public object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }
                    result = command.ExecuteScalar();
                }
            }
            return result;
        }
    }
}