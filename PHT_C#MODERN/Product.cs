using System;
using System.Collections.Generic;
using System.Linq;

// Định nghĩa các class cần thiết
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public int Stock { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Program
{
    public static void Main()
    {
        // 1. Khởi tạo dữ liệu mẫu
        var categories = new List<Category> 
        {
            new Category { Id = 1, Name = "Điện tử" },
            new Category { Id = 2, Name = "Phụ kiện" }
        };

        var products = new List<Product> 
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500, CategoryId = 1, Stock = 10 },
            new Product { Id = 2, Name = "Mouse", Price = 25, CategoryId = 2, Stock = 50 },
            new Product { Id = 3, Name = "Keyboard", Price = 75, CategoryId = 2, Stock = 0 },
            new Product { Id = 4, Name = "Monitor", Price = 300, CategoryId = 1, Stock = 5 }
        };

        // --- BÀI TẬP LINQ ---

        // Câu hỏi 1: GroupBy - Nhóm dữ liệu theo CategoryId
        var summary = products.GroupBy(p => p.CategoryId)
                             .Select(g => new 
                             {
                                 CategoryId = g.Key,
                                 ProductCount = g.Count(),
                                 TotalValue = g.Sum(p => p.Price * p.Stock)
                             })
                             .ToList();

        // Câu hỏi 2: Join - Kết nối bảng Products và Categories
        var productDetails = products.Join(
            categories,
            p => p.CategoryId,
            c => c.Id,
            (p, c) => new 
            {
                ProductName = p.Name,
                CategoryName = c.Name,
                Price = p.Price
            })
            .ToList();

        // 2. Xuất kết quả ra màn hình để kiểm tra
        Console.WriteLine("--- THỐNG KÊ THEO CATEGORY ---");
        summary.ForEach(s => Console.WriteLine($"Category: {s.CategoryId}, Count: {s.ProductCount}, Value: {s.TotalValue}"));

        Console.WriteLine("\n--- CHI TIẾT SẢN PHẨM (JOIN) ---");
        productDetails.ForEach(d => Console.WriteLine($"{d.ProductName} | {d.CategoryName} | Price: {d.Price}"));
    }
}