using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Shop2.Database;
using Shop2.Entities;

namespace Shop2.Services;

public class ProductService
{
    private ApplicationContext _context;

    public ProductService(ApplicationContext context)
    {
        _context = context;
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
    }

    public List<Product> GetProducts(int page)
    {
        var skip = (page - 1) * 10;
        var products = _context.Products.OrderBy(x=>x.Id).Skip(skip).Take(10).ToList();
        return products;
    }
    
    public int GetProductCount()
    {
        var count = _context.Products.Count();
        return count;
    }

    public Product GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

  
}