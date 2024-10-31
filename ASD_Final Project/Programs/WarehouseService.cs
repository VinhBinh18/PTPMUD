using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;


namespace ASD_Final_Project.Program
{
    public class WarehouseService
    {
        private readonly ProductService  _productService;
        private Timer _updateTimer;

        public event Action<List<Product>> OnProductsUpdated;
        private readonly int _warehouseId;

        public WarehouseService(ProductService inventoryService, int warehouseId)
        {
            _productService = inventoryService;
            _warehouseId = warehouseId; // Gán warehouseId
            _updateTimer = new Timer(1000); // Cập nhật mỗi 1 giây
            _updateTimer.Elapsed += OnTimedEvent;
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            // Lấy dữ liệu từ kho và gọi sự kiện để cập nhật giao diện
            var products = _productService.GetAllProducts(_warehouseId).ToList();
            OnProductsUpdated?.Invoke(products);
        }
    }
}
