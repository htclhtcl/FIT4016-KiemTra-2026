using System;

namespace Constructor
{
    // Lớp Product với Constructor
    class Product
    {
        public int ProductId;
        public string ProductName;
        public double Price;

        public Product(int productId, string productName, double price)
        {
            ProductId = productId;
            ProductName = productName;
            Price = price;
        }

        public void Display()
        {
            Console.WriteLine($"ID: {ProductId}, Name: {ProductName}, Price: {Price}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tạo bằng constructor
            Product p = new Product(101, "Laptop", 1500);

            // In thông tin
            p.Display();
        }
    }
}
