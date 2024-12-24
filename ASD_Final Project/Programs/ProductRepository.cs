using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                _dbConnection.Open();
                using (var command = new SqlCommand(@"SELECT P.P_ID, P.P_Name, P.P_Price, O.O_Name, CU.Un_Name, S.S_Name, W.Wh_Name FROM  Products P JOIN  Origin O ON P.O_ID = O.O_ID JOIN Calculation_Unit CU ON P.Un_ID = CU.Un_ID JOIN Suppliers S ON P.S_ID = S.S_ID JOIN WH_Transaction_Details TD ON P.P_ID = TD.P_ID JOIN WH_Transaction WT ON TD.T_ID = WT.T_ID JOIN Warehouse W ON WT.Wh_ID = W.Wh_ID;", _dbConnection))
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
                // Xử lý lỗi nếu cần
                MessageBox.Show($"Error: {ex.Message} + 1");
            }
            finally
            {
                _dbConnection.Close();
            }

            return products;
        }

        public IEnumerable<Product> GetAllProducts(int warehouseId)
        {
            var products = new List<Product>();

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand(@"SELECT P.P_ID, P.P_Name, P.P_Price, O.O_Name, CU.Un_Name, S.S_Name, W.Wh_Name FROM Products P JOIN Origin O ON P.O_ID = O.O_ID JOIN Calculation_Unit CU ON P.Un_ID = CU.Un_ID JOIN Suppliers S ON P.S_ID = S.S_ID JOIN WH_Transaction_Details TD ON P.P_ID = TD.P_ID JOIN WH_Transaction WT ON TD.T_ID = WT.T_ID JOIN Warehouse W ON WT.Wh_ID = W.Wh_ID WHERE WT.Wh_ID = @WarehouseId;", _dbConnection))
                {
                    command.Parameters.AddWithValue("@WarehouseId", warehouseId);

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
                // Xử lý lỗi nếu cần
                MessageBox.Show($"Error: {ex.Message} + 1");
            }
            finally
            {
                _dbConnection.Close();
            }

            return products;
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
}

