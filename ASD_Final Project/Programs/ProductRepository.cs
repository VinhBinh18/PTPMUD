using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Odbc;

namespace ASD_Final_Project.Program
{
    public class ProductRepository
    {
        private readonly SqlConnection _dbConnection;

        public ProductRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var products = new List<Product>();

            try
            {
                if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }
                using (var command = new SqlCommand(@"SELECT P.P_ID, P.P_Name, P.P_Price, O.O_Name, CU.Un_Name, S.S_Name, W.Wh_Name 
                                              FROM Products P 
                                              JOIN Origin O ON P.O_ID = O.O_ID 
                                              JOIN Calculation_Unit CU ON P.Un_ID = CU.Un_ID 
                                              JOIN Suppliers S ON P.S_ID = S.S_ID 
                                              JOIN WH_Transaction_Details TD ON P.P_ID = TD.P_ID 
                                              JOIN WH_Transaction WT ON TD.T_ID = WT.T_ID 
                                              JOIN Warehouse W ON WT.Wh_ID = W.Wh_ID;",
                                                      _dbConnection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Price = reader.GetDouble(2),
                                Origin = reader.GetString(3),
                                Unit = reader.GetString(4),
                                Supplier = reader.GetString(5),
                                Warehouse = reader.GetString(6),
                            };
                            products.Add(product);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message} + 1");
            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }

            return products;
        }

        public IEnumerable<Product> GetAllProducts(int warehouseId)
        {
            var products = new List<Product>();

            try
            {
                using (var conn = new SqlConnection(_dbConnection.ConnectionString)) // Tạo kết nối mới để đảm bảo không chia sẻ kết nối
                {
                    conn.Open();

                    using (var command = new SqlCommand(@"SELECT P.P_ID, P.P_Name, P.P_Price, O.O_Name, CU.Un_Name, S.S_Name, W.Wh_Name
                                                  FROM Products P 
                                                  JOIN Origin O ON P.O_ID = O.O_ID 
                                                  JOIN Calculation_Unit CU ON P.Un_ID = CU.Un_ID 
                                                  JOIN Suppliers S ON P.S_ID = S.S_ID 
                                                  JOIN WH_Transaction_Details TD ON P.P_ID = TD.P_ID 
                                                  JOIN WH_Transaction WT ON TD.T_ID = WT.T_ID 
                                                  JOIN Warehouse W ON WT.Wh_ID = W.Wh_ID 
                                                  WHERE WT.Wh_ID = @WarehouseId;", conn)) // Sử dụng kết nối hiện tại
                    {
                        command.Parameters.AddWithValue("@WarehouseId", warehouseId); // Thêm tham số WarehouseId

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Price = reader.GetDouble(2),
                                    Origin = reader.GetString(3),
                                    Unit = reader.GetString(4),
                                    Supplier = reader.GetString(5),
                                    Warehouse = reader.GetString(6),
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }
            finally
            {
                if (_dbConnection.State == ConnectionState.Open)
                {
                    _dbConnection.Close();
                }
            }

            return products;
        }

        public void InventoryProduct(DataGridView dgv)
        {
            string query = @"
            WITH TransactionStatus AS 
            (
                SELECT 
                    p.P_Name AS ProductName,
                    w.Wh_Name AS Warehouse,
                    t.T_Note AS TransactionNote,
                    t.T_EntryDate AS EntryDate,
                    t.T_ExportDate AS ExportDate,
                    DATEDIFF(DAY, t.T_EntryDate, COALESCE(t.T_ExportDate, GETDATE())) AS DaysInStorage,
                    CASE
                        WHEN t.T_ExportDate IS NULL THEN 'Not Shipped'
                        WHEN DATEDIFF(DAY, t.T_EntryDate, t.T_ExportDate) <= 20 THEN 'In Transit'
                        ELSE 'Delivered'
                    END AS Status
                FROM 
                    WH_Transaction t
                    JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
                    JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
                    JOIN Products p ON td.P_ID = p.P_ID
                WHERE 
                    DATEDIFF(DAY, t.T_EntryDate, COALESCE(t.T_ExportDate, GETDATE())) > 20
            )

            SELECT 
                ProductName,
                Warehouse,
                TransactionNote,
                EntryDate,
                ExportDate,
                DaysInStorage,
                Status
            FROM 
                TransactionStatus
            WHERE 
                Status = 'Not Shipped' -- Lọc sản phẩm chưa xuất (đang tồn kho)
            ORDER BY 
                DaysInStorage DESC;
                ";

            try
            {
                using (var conn = new SqlConnection(_dbConnection.ConnectionString))
                {
                    conn.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                    {
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgv.DataSource = table;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public void InventoryProduct(DataGridView dgv, int wh_id)
        {
            string query = @"
            WITH TransactionStatus AS 
            (
                SELECT 
                    p.P_Name AS ProductName,
                    w.Wh_ID,
                    w.Wh_Name AS Warehouse,
                    t.T_Note AS TransactionNote,
                    t.T_EntryDate AS EntryDate,
                    t.T_ExportDate AS ExportDate,
                    DATEDIFF(DAY, t.T_EntryDate, COALESCE(t.T_ExportDate, GETDATE())) AS DaysInStorage,
                    CASE
                        WHEN t.T_ExportDate IS NULL THEN 'Not Shipped'
                        WHEN DATEDIFF(DAY, t.T_EntryDate, t.T_ExportDate) <= 20 THEN 'In Transit'
                        ELSE 'Delivered'
                    END AS Status
                FROM 
                    WH_Transaction t
                    JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
                    JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
                    JOIN Products p ON td.P_ID = p.P_ID
                WHERE 
                    DATEDIFF(DAY, t.T_EntryDate, COALESCE(t.T_ExportDate, GETDATE())) > 20
             )

            SELECT 
                ProductName,
                Warehouse,
                TransactionNote,
                EntryDate,
                ExportDate,
                DaysInStorage,
                Status
            FROM 
                TransactionStatus
            WHERE 
                Wh_ID = @WarehouseID  -- Thay thế bằng Wh_ID cần truy xuất
            ORDER BY 
                Status, DaysInStorage DESC;
                ";

            try
            {
                using (var conn = new SqlConnection(_dbConnection.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WarehouseID", wh_id);

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dgv.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public void OrderProduct(DataGridView dgv)
        {
            string query = @"
            SELECT 
                w.Wh_Name AS WarehouseName,
                p.P_Name AS ProductName,
                p.P_Price AS ProductPrice,
                td.TD_Quantity AS Quantity,
                t.T_Note AS TransactionNote,
                t.T_EntryDate AS EntryDate,
                t.T_ExportDate AS ExportDate,
                u.U_UserName AS ProcessedBy,
                CASE
                    WHEN t.T_ExportDate IS NULL THEN 'Not Shipped'
                    WHEN DATEDIFF(DAY, t.T_EntryDate, t.T_ExportDate) <= 20 THEN 'In Transit'
                    ELSE 'Delivered'
                END AS Status
            FROM 
                WH_Transaction t
                JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
                JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
                JOIN Products p ON td.P_ID = p.P_ID
                JOIN Users u ON t.Wh_ID = u.Wh_ID -- Assuming Users table has info about who processes orders by warehouse
            ORDER BY 
                w.Wh_Name, t.T_EntryDate DESC;
                ";

            try
            {
                using (var conn = new SqlConnection(_dbConnection.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
 
                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dgv.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public void OrderProduct(DataGridView dgv, int wh_id)
        {
            string query = @"
            SELECT 
                w.Wh_Name AS WarehouseName,
                p.P_Name AS ProductName,
                p.P_Price AS ProductPrice,
                td.TD_Quantity AS Quantity,
                t.T_Note AS TransactionNote,
                t.T_EntryDate AS EntryDate,
                t.T_ExportDate AS ExportDate,
                u.U_UserName AS ProcessedBy,
                CASE
                    WHEN t.T_ExportDate IS NULL THEN 'Not Shipped'
                    WHEN DATEDIFF(DAY, t.T_EntryDate, t.T_ExportDate) <= 20 THEN 'In Transit'
                    ELSE 'Delivered'
                END AS Status
            FROM 
                WH_Transaction t
                JOIN WareHouse w ON t.Wh_ID = w.Wh_ID
                JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID
                JOIN Products p ON td.P_ID = p.P_ID
                JOIN Users u ON t.Wh_ID = u.Wh_ID -- Assuming Users table has info about who processes orders by warehouse
            WHERE
                t.Wh_ID = @WarehouseID  -- Replace @Wh_ID with the actual warehouse ID you want to filter by
            ORDER BY 
                w.Wh_Name, t.T_EntryDate DESC;

                ";

            try
            {
                using (var conn = new SqlConnection(_dbConnection.ConnectionString))
                {
                    conn.Open();
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@WarehouseID", wh_id);

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            dgv.DataSource = table;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        public int CountOrder()
        {
            int count = 0;
            string query = "SELECT COUNT(*) AS TotalCount FROM WH_Transaction t JOIN WareHouse w ON t.Wh_ID = w.Wh_ID JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID JOIN Products p ON td.P_ID = p.P_ID JOIN Users u ON t.Wh_ID = u.Wh_ID";
            try
            {
                using (var con = new SqlConnection(_dbConnection.ConnectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(query, con))
                    {
                        count = cmd.ExecuteNonQuery();
                        return count;
                    }
                }    
            }catch (Exception ex)
            {
                MessageBox.Show("Can't Count User: errol: "+ ex.Message);
            }
            return count;
        }

        public int CountOrder(int wh_id)
        {
            int count = 0;
            string query = "";
            try
            {
                using (var con = new SqlConnection(_dbConnection.ConnectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand(query, con))
                    {
                        count = cmd.ExecuteNonQuery();
                        return count;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't Count User: errol: " + ex.Message);
            }
            return count;//not yet
        }
    }

    /*        public void AddProduct(Product product)
            {
                try
                {
                    _dbConnection.Open();
                    using (var command = new SqlCommand("INSERT INTO Products (Name, Quantity, WarehouseId) VALUES (@Name, @Quantity, @WarehouseId)", _dbConnection))
                    {
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);
                        command.Parameters.AddWithValue("@WarehouseId", product.WarehouseId); // Assuming WarehouseId is part of Product

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public void UpdateProduct(Product product)
            {
                try
                {
                    _dbConnection.Open();
                    using (var command = new SqlCommand("UPDATE Products SET Name = @Name, Quantity = @Quantity WHERE Id = @Id", _dbConnection))
                    {
                        command.Parameters.AddWithValue("@Id", product.Id);
                        command.Parameters.AddWithValue("@Name", product.Name);
                        command.Parameters.AddWithValue("@Quantity", product.Quantity);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public void DeleteProduct(int productId)
            {
                try
                {
                    _dbConnection.Open();
                    using (var command = new SqlCommand("DELETE FROM Products WHERE Id = @Id", _dbConnection))
                    {
                        command.Parameters.AddWithValue("@Id", productId);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi nếu cần
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    _dbConnection.Close();
                }
            }*/
}

