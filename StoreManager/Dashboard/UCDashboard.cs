using System;
using System.Data;
using StoreManager.Utils;

namespace StoreManager
{
    public partial class UCDashboard : UserControl
    {
        public UCDashboard()
        {
            InitializeComponent();
            SetupCard(card1, lblRevenue, "DOANH THU", Color.FromArgb(46, 204, 113));
            SetupCard(card2, lblItemsSold, "SẢN PHẨM", Color.FromArgb(52, 152, 219));
            SetupCard(card3, lblActiveCustomers, "KHÁCH HÀNG", Color.FromArgb(243, 156, 18));
            SetupCard(card4, lblOrders, "ĐƠN HÀNG", Color.FromArgb(155, 89, 182));
            cbPeriod.SelectedIndex = 1; // Mặc định chọn "7 ngày qua"
        }

        public void RefreshDashboard()
        {
            string period = cbPeriod.SelectedItem.ToString();
            string dateFilter = GetSqlDateFilter(period);

            LoadTopCards(dateFilter);
            LoadRevenueChart(period);
            LoadCategoryChart(dateFilter);
        }

        private void LoadTopCards(string dateFilter)
        {
            try
            {
                // 1. Doanh thu
                string sqlRev = $"SELECT SUM(inv_price) FROM Invoices WHERE {dateFilter}";
                object rev = DatabaseConnector.Instance.ExecuteScalar(sqlRev);
                lblRevenue.Text = FormatMoney(rev);

                // 2. Sản phẩm đã bán
                string sqlItems = $"SELECT SUM(d.ind_count) FROM Invoice_details d JOIN Invoices i ON d.inv_ID = i.inv_ID WHERE {dateFilter}";
                object items = DatabaseConnector.Instance.ExecuteScalar(sqlItems);
                lblItemsSold.Text = items == DBNull.Value ? "0" : items.ToString();

                // 3. Khách hàng mới
                string sqlCus = $"SELECT COUNT(DISTINCT cus_ID) FROM Invoices WHERE {dateFilter}";
                object cus = DatabaseConnector.Instance.ExecuteScalar(sqlCus);
                lblActiveCustomers.Text = cus.ToString();

                // 4. Tổng đơn hàng
                string sqlOrd = $"SELECT COUNT(*) FROM Invoices WHERE {dateFilter}";
                object ord = DatabaseConnector.Instance.ExecuteScalar(sqlOrd);
                lblOrders.Text = ord.ToString();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải thẻ: " + ex.Message); }
        }

        private void LoadRevenueChart(string period)
        {
            string dateSelect = "";
            string groupBy = "";
            string orderBy = "";

            if (period == "Hôm nay")
            {
                // Lấy theo giờ. VD: 14:00
                dateSelect = "FORMAT(inv_date, 'HH:00')";
                groupBy = "DATEPART(hour, inv_date)";
                orderBy = "DATEPART(hour, inv_date)";
            }
            else
            {
                // Lấy theo ngày/tháng. VD: 25/12
                dateSelect = "FORMAT(inv_date, 'dd/MM')";
                groupBy = "CAST(inv_date AS DATE)";
                orderBy = "CAST(inv_date AS DATE)";
            }

            string dateFilter = GetSqlDateFilter(period);

            string sql = $"SELECT {dateSelect} as d, SUM(inv_price) as total " +
                         $"FROM Invoices " +
                         $"WHERE {dateFilter} " +
                         $"GROUP BY {groupBy}, {dateSelect} " +
                         $"ORDER BY {orderBy} ASC";

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql);

            List<string> labels = new List<string>();
            List<double> values = new List<double>();

            foreach (DataRow row in dt.Rows)
            {
                labels.Add(row["d"].ToString());
                values.Add(Convert.ToDouble(row["total"]));
            }

            // Nạp dữ liệu vào Chart
            barChartRevenue.LoadData(labels, values, period);
        }

        private void LoadCategoryChart(string dateFilter)
        {
            // Logic lấy dữ liệu cho biểu đồ tròn (Donut Chart)
            string sql = $@"SELECT t.type_name, SUM(d.ind_count) as total 
                            FROM Invoice_details d 
                            JOIN Products p ON d.pro_ID = p.pro_ID 
                            JOIN ProductTypes t ON p.type_ID = t.type_ID 
                            JOIN Invoices i ON d.inv_ID = i.inv_ID 
                            WHERE {dateFilter} 
                            GROUP BY t.type_name ORDER BY total DESC";

            DataTable dt = DatabaseConnector.Instance.ExecuteQuery(sql);
            Dictionary<string, double> data = new Dictionary<string, double>();
            foreach (DataRow row in dt.Rows)
            {
                data.Add(row["type_name"].ToString(), Convert.ToDouble(row["total"]));
            }
            donutChartCategory.LoadData(data);
        }

        private string GetSqlDateFilter(string period)
        {
            return period switch
            {
                "Hôm nay" => "CAST(inv_date AS DATE) = CAST(GETDATE() AS DATE)",
                "Tháng này" => "MONTH(inv_date) = MONTH(GETDATE()) AND YEAR(inv_date) = YEAR(GETDATE())",
                "Năm nay" => "YEAR(inv_date) = YEAR(GETDATE())",
                _ => "inv_date >= DATEADD(day, -7, GETDATE())" // Mặc định 7 ngày
            };
        }

        private string FormatMoney(object val)
        {
            if (val == DBNull.Value || val == null) return "0 VND";
            double m = Convert.ToDouble(val);
            return m >= 1000000 ? (m / 1000000.0).ToString("0.#") + " Tr" : (m / 1000.0).ToString("0") + " K";
        }

        private void cbPeriod_SelectedIndexChanged(object sender, EventArgs e) => RefreshDashboard();
        private void btnRefresh_Click(object sender, EventArgs e) => RefreshDashboard();
    }
}