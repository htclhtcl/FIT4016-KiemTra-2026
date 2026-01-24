using System;

namespace CSharpModernExercise
{
    // --- BÀI TẬP 2: RECORD ---
    // TODO 1: Viết một record có tên ProductDTO
    public record ProductDTO(int Id, string Name, decimal Price);

    public class Program
    {
        public static void Main(string[] args)
        {
            // --- THỰC THI BÀI TẬP 2 ---
            Console.WriteLine("--- Bài tập 2: Record ---");
            
            // TODO 2: Tạo một instance của ProductDTO
            var product = new ProductDTO(1, "Laptop", 1000);
            Console.WriteLine($"Gốc: {product}");

            // TODO 3: Tạo một bản copy với giá giảm 10% (dùng with expression)
            var discounted = product with { Price = product.Price * 0.9m };
            Console.WriteLine($"Sau khi giảm giá 10%: {discounted}");


            // --- THỰC THI BÀI TẬP 3 ---
            Console.WriteLine("\n--- Bài tập 3: Switch Expression ---");
            
            string type1 = "Electronics";
            string type2 = "Unknown";
            
            Console.WriteLine($"Thuế của {type1}: {GetTaxRate(type1)}%");
            Console.WriteLine($"Thuế của {type2}: {GetTaxRate(type2)}%");
        }

        // --- BÀI TẬP 3: SWITCH EXPRESSION ---
        // Hàm nhận vào loại sản phẩm và trả về mã thuế
        public static int GetTaxRate(string productType) => productType switch
        {
            "Electronics" => 10,
            "Food"        => 5,
            "Clothing"    => 8,
            _             => 0 // Trường hợp mặc định (Discard)
        };
    }
}