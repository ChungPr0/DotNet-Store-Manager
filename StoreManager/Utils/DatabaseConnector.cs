
using System.Data;
using Microsoft.Data.SqlClient;

namespace StoreManager.Utils
{
    public class DatabaseConnector
    {
        string connectionString = "Server=.\\SQLEXPRESS;Database=StoreManager;Integrated Security=True;TrustServerCertificate=True;";

        // Sử dụng pattern Singleton để dễ gọi hàm từ bất kỳ đâu mà không cần new nhiều lần
        private static DatabaseConnector instance;
        public static DatabaseConnector Instance
        {
            get { if (instance == null) instance = new DatabaseConnector(); return instance; }
            private set { instance = value; }
        }

        // Constructor private để cấm tạo object bừa bãi
        private DatabaseConnector() { }

        // ======================================================
        // HÀM 1: Dùng cho câu lệnh SELECT (Trả về 1 bảng dữ liệu)
        // ======================================================
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

        // ======================================================
        // HÀM 4: Dùng để kiểm tra kết nối lúc khởi động app
        // ======================================================
        public bool TestConnection(out string errorMessage)
        {
            errorMessage = string.Empty;
            string testConnectionString = connectionString + (connectionString.EndsWith(";") ? "" : ";") + "Connection Timeout=3;";

            try
            {
                using (SqlConnection connection = new SqlConnection(testConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message; // Bắt lấy lỗi để mang ra ngoài thông báo
                return false;
            }
        }
    }
}