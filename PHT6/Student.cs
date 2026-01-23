using System;

// --- PHẦN CHẠY CHƯƠNG TRÌNH (Thay thế cho hàm Main) ---
try 
{
    // Khởi tạo một sinh viên mới
    Student sv = new Student("SV001", "Nguyễn Văn A", 8.5);
    
    // Hiển thị thông tin
    Console.WriteLine("--- Thông tin sinh viên ---");
    sv.Display();
}
catch (Exception ex)
{
    // In ra lỗi nếu validation thất bại
    Console.WriteLine($"Lỗi: {ex.Message}");
}


// --- PHẦN ĐỊNH NGHĨA LỚP STUDENT ---
public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }

    public Student(string id, string name, double score)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("StudentId không được rỗng");

        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Tên không được rỗng");

        if (score < 0 || score > 10)
            throw new ArgumentOutOfRangeException(nameof(score), "Điểm phải từ 0 đến 10");

        StudentId = id;
        Name = name;
        Score = score;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {StudentId} | Tên: {Name} | Điểm: {Score}");
    }
}