using Microsoft.AspNetCore.Mvc;
using Shop2.Models;

namespace Shop2.Controllers;

public class ProductController : Controller
{
    private static List<Product> _products = new List<Product>()
    {
        new Product()
        {
            Id = 1,
            Name = "Laptop Asus TUF Gaming",
            Brand = "Asus",
            Price = 20000,
            Rate = 4,
            Quantity = 10,
            Description = "Good laptop"
        },
        new Product()
        {
            Id = 2,
            Name = "Optical Mouse",
            Brand = "A2Tech",
            Price = 200,
            Rate = 3,
            Quantity = 50,
            Description = "Good Mouse"
        },
        new Product()
        {
            Id=1002,
            Name = "Wireless headset",
            Brand = "A4Tech",
            Price = 50000,
            Rate = 5,
            Quantity = 25,
            Description = "Good headset"
        },
        new Product()
        {
            Id = 5000,
            Name = "TV LG 32 inches",
            Brand = "LG",
            Price = 500000,
            Rate = 4,
            Quantity = 2,
            Description = "Good TV 4K"
        }
    };
    
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult List()
    {
        return View(_products);
    }

    public IActionResult Details(int id)
    {
        var product = _products.First(item => item.Id == id);
        
        
        return View(product);
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddProduct(Product product)
    {

        if (ModelState.IsValid)
        {
            product.Id = _products.Max(x => x.Id)+1;
            _products.Add(product);
            return RedirectToAction("AddProduct");
        }

        return View(product);
    }
}