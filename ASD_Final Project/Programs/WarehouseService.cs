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
        private readonly UserService _userService;
        private readonly Timer _updateTimer;

        public event Action<List<Product>> OnProductsUpdated;
        public event Action<List<User>> OnUsersUpdated;
        private readonly int _warehouseId;

        public WarehouseService(ProductService productService, int warehouseId)
        {
            _productService = productService;
            _warehouseId = warehouseId; // Gán warehouseId
            _updateTimer = new Timer(1000); // Cập nhật mỗi 1 giây
            _updateTimer.Elapsed += OnTimedEventProduct;
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        public WarehouseService(UserService userService, int warehouseId)
        {
            _userService = userService;
            _warehouseId = warehouseId; // Gán warehouseId
            _updateTimer = new Timer(1000); // Cập nhật mỗi 1 giây
            _updateTimer.Elapsed += OnTimedEventUser;
            _updateTimer.AutoReset = true;
            _updateTimer.Start();
        }

        private void OnTimedEventUser(object sender, ElapsedEventArgs e)
        {
            var users = _userService.GetAllUsers(_warehouseId).ToList();
            OnUsersUpdated?.Invoke(users);
        }

        private void OnTimedEventProduct(object sender, ElapsedEventArgs e)
        {
            // Lấy dữ liệu từ kho và gọi sự kiện để cập nhật giao diện
            var products = _productService.GetAllProducts(_warehouseId).ToList();
            OnProductsUpdated?.Invoke(products);
        }
    }
}
