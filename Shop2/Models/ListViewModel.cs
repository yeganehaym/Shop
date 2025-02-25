using Shop2.Entities;

namespace Shop2.Models;

public class ListViewModel
{
    public int TotalPage { get; set; }
    public int TotalProducts { get; set; }
    public List<ProductViewModel> Products { get; set; }
}