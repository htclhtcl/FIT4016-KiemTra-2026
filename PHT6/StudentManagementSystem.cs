using System;
using System.Collections.Generic; // Cần thiết để dùng List
using System.Linq; // Cần thiết để dùng các hàm tính toán nhanh như Average, Max

namespace StudentManagementSystem
{
    // 1. Lớp Student: Giữ nguyên logic nhưng dùng gọn hơn
    public class Student
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }

        public Student(string id, string name, double score)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new ArgumentException("ID không được để trống");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Tên không được để trống");
            if (score < 0 || score > 10) throw new ArgumentOutOfRangeException("Điểm phải từ 0 đến 10");

            StudentId = id;
            Name = name;
            Score = score;
        }

        public void Display() => Console.WriteLine($"ID: {StudentId,-10} | Tên: {Name,-20} | Điểm: {Score}");
    }

    // 2. Lớp StudentManager: Sử dụng List để quản lý linh hoạt hơn
    public class StudentManager
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(string id, string name, double score)
        {
            if (students.Any(s => s.StudentId == id))
            {
                Console.WriteLine("Lỗi: Mã sinh viên này đã tồn tại!");
                return;
            }
            students.Add(new Student(id, name, score));
            Console.WriteLine("Thêm thành công!");
        }

        public void RemoveStudent(string id)
        {
            int removedCount = students.RemoveAll(s => s.StudentId == id);
            Console.WriteLine(removedCount > 0 ? "Đã xóa sinh viên." : "Không tìm thấy ID này.");
        }

        public void UpdateScore(string id, double newScore)
        {
            var student = students.FirstOrDefault(s => s.StudentId == id);
            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên!");
                return;
            }
            if (newScore < 0 || newScore > 10) { Console.WriteLine("Điểm không hợp lệ!"); return; }
            
            student.Score = newScore;
            Console.WriteLine("Cập nhật điểm thành công!");
        }

        public void DisplayAll()
        {
            if (students.Count == 0) { Console.WriteLine("Danh sách trống!"); return; }
            Console.WriteLine("\n--- DANH SÁCH SINH VIÊN ---");
            students.ForEach(s => s.Display());
        }

        // Sử dụng LINQ để tính toán cực nhanh
        public double GetAverage() => students.Count > 0 ? students.Average(s => s.Score) : 0;
        public double GetMax() => students.Count > 0 ? students.Max(s => s.Score) : 0;
        public Student FindById(string id) => students.FirstOrDefault(s => s.StudentId == id);
    }

    // 3. Lớp Program: Giao diện Menu
    class Program
    {
        static void Main()
        {
            // Thiết lập Encoding để hiển thị tiếng Việt nếu cần
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            StudentManager manager = new StudentManager();

            while (true)
            {
                Console.WriteLine("\n==== QUẢN LÝ SINH VIÊN ====");
                Console.WriteLine("1. Thêm | 2. Xóa | 3. Cập nhật | 4. Xem hết | 5. TB | 6. Max | 7. Tìm | 0. Thoát");
                Console.Write("Chọn chức năng: ");

                try
                {
                    string choice = Console.ReadLine();
                    if (choice == "0") break;

                    switch (choice)
                    {
                        case "1":
                            Console.Write("ID: "); string id = Console.ReadLine();
                            Console.Write("Tên: "); string name = Console.ReadLine();
                            Console.Write("Điểm: "); double sc = double.Parse(Console.ReadLine());
                            manager.AddStudent(id, name, sc);
                            break;
                        case "2":
                            Console.Write("Nhập ID xóa: "); 
                            manager.RemoveStudent(Console.ReadLine());
                            break;
                        case "3":
                            Console.Write("ID: "); string uid = Console.ReadLine();
                            Console.Write("Điểm mới: "); double nsc = double.Parse(Console.ReadLine());
                            manager.UpdateScore(uid, nsc);
                            break;
                        case "4":
                            manager.DisplayAll();
                            break;
                        case "5":
                            Console.WriteLine($"Điểm trung bình: {manager.GetAverage():F2}");
                            break;
                        case "6":
                            Console.WriteLine($"Điểm cao nhất: {manager.GetMax()}");
                            break;
                        case "7":
                            Console.Write("Nhập ID: ");
                            var s = manager.FindById(Console.ReadLine());
                            if (s != null) s.Display(); else Console.WriteLine("Không thấy!");
                            break;
                        default:
                            Console.WriteLine("Lựa chọn sai!");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi nhập liệu: {ex.Message}");
                }
            }
        }
    }
}