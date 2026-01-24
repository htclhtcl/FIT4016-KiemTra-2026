// Bài 1:
var result = products.Where(p => p.Price > 100).ToList();

// Bài 2: (Cần sửa để lấy cả Name và Price)
var productNamesAndPrices = products.Select(p => new { 
    p.Name, 
    p.Price 
}).ToList();

// Bài 3:
var top2Expensive = products.OrderByDescending(p => p.Price).Take(2).ToList();

// Bài 4:
int pageNumber = 2;
int pageSize = 2;
var pagedProducts = products.OrderBy(p => p.Id)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .ToList();

// Bài 5:
int countInStock = products.Count(p => p.Stock > 0);
bool hasCheapProduct = products.Any(p => p.Price < 50);
bool allHavePrice = products.All(p => p.Price > 0);