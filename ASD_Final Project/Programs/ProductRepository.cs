using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD_Final_Project.Program
{
    public class ProductRepository
    {
        private readonly SqlConnection _dbConnection;

        public ProductRepository(string connectionString)
        {
            _dbConnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Product> GetAllProducts(int warehouseId)
        {
            var products = new List<Product>();

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand("SELECT Id, Name, Quantity FROM Products WHERE WarehouseId = @WarehouseId", _dbConnection))
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
                                Quantity = reader.GetInt32(2)
                            };
                            products.Add(product);
                        }
                    }
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

            return products;
        }

        public void AddProduct(Product product)
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
        }


        public IEnumerable<Product> GetProductsByWareHouseName(string warehouseName)
        {
            var products = new List<Product>();
            string query = "SELECT w.Wh_Name AS WarehouseName, p.P_Name AS ProductName, SUM(td.TD_Quantity) AS TotalQuantity FROM  WH_Transaction t JOIN WareHouse w ON t.Wh_ID = w.Wh_ID JOIN WH_Transaction_Details td ON t.T_ID = td.T_ID  JOIN Products p ON td.P_ID = p.P_ID WHERE    w.Wh_Name = @WarehouseName GROUP BY    w.Wh_Name, p.P_Name ORDER BY   p.P_Name";

            try
            {
                _dbConnection.Open();
                using (var command = new SqlCommand(query, _dbConnection))
                {
                    command.Parameters.AddWithValue("@WarehouseName", warehouseName);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Quantity = reader.GetInt32(2)
                            };
                            products.Add(product);
                        }
                    }
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

            return products;
        }




    }
}

