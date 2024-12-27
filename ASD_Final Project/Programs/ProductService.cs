using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASD_Final_Project.Program
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts(int warehouseId)
        {
            return _productRepository.GetAllProducts(warehouseId);
        }
        
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }
        public int CountProduct(int warehouseId)
        {
            return _productRepository.GetAllProducts(warehouseId).Count();
        } 
        public int CountProducts()
        {
            return _productRepository.GetAllProducts().Count();
        }

        public void InventoryProduct(DataGridView dgv)
        {
            _productRepository.InventoryProduct(dgv);
        }

        public void InventoryProduct(DataGridView dgv, int wh_id)
        {
            _productRepository.InventoryProduct(dgv,wh_id);
        }

        public void OrderProduct(DataGridView dgv)
        {
            _productRepository.OrderProduct(dgv);
        }

        public void OrderProduct(DataGridView dgv,int wh_id)
        {
            _productRepository.OrderProduct(dgv,wh_id);
        }

        public int CountOrder()
        {
            return _productRepository.CountOrder();
        }
        public int CountOrder(int wh_id)
        {
            return _productRepository.CountOrder(wh_id);
        }

        /*        public void AddProduct(Product product)
                {
                    _productRepository.AddProduct(product);
                }

                public void UpdateProduct(Product product)
                {
                    _productRepository.UpdateProduct(product);
                }

                public void DeleteProduct(int productId)
                {
                    _productRepository.DeleteProduct(productId);
                }*/
    }
}
