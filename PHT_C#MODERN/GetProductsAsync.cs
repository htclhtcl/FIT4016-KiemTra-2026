using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ProductService
{
    // TODO 1: Khai báo một hàm async có tên là GetProductsAsync() trả về Task<List<Product>>
    public async Task<List<Product>> GetProductsAsync()
    {
        // Giả lập một khoảng trễ (ví dụ: lấy dữ liệu từ Database hoặc API)
        await Task.Delay(1000); 

        // Khởi tạo danh sách sản phẩm mẫu
        var products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop Dell XPS" },
            new Product { Id = 2, Name = "iPhone 15 Pro" },
            new Product { Id = 3, Name = "Bàn phím cơ Akko" }
        };

        return products;
    }
}