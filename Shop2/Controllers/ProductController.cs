using Mapster;
using Microsoft.AspNetCore.Mvc;
using Shop2.Database;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Controllers;

public class ProductController : Controller
{
    private ApplicationContext _applicationContext;

    public ProductController(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }


    public IActionResult Index()
    {
        return View();
    }
    public IActionResult List(int page=1)
    {
        var skip = (page - 1) * 10;
        var products = _applicationContext.Products.OrderBy(x=>x.Id).Skip(skip).Take(10).ToList();
        var count = _applicationContext.Products.Count();
        var totalPage =(int) Math.Ceiling(count / 10f);

        /*var list = new List<ProductViewModel>();
        foreach (Product product in products)
        {
            var pvm=new ProductViewModel()
            {
                Id=product.Id,
                Rate = product.Rate,
                Description = product.Description,
                Price = product.Price,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                Brand = product.Brand,
            };
            list.Add(pvm);
        }*/
        
        /*var list = products
            .Select(product => new ProductViewModel()
            {
                Id = product.Id,
                Rate = product.Rate,
                Description = product.Description,
                Price = product.Price,
                Name = product.Name,
                CategoryId = product.CategoryId,
                Quantity = product.Quantity,
                Brand = product.Brand,
            })
            .ToList();*/

        var list = products.Adapt<List<ProductViewModel>>();
        
        
        var vm = new ListViewModel()
        {
            TotalPage = totalPage,
            Products = list,
            TotalProducts = count
        };
        return View(vm);
    }

    public IActionResult AddMore()
    {
        for (var i = 0; i < 20; i++)
        {
            var p = new Product()
            {
                Rate = 3,
                Quantity = 12,
                Name = "Product "+ i,
                Brand = "Brand " + i,
                Price = 58000,
                Description = "Desc "+ i
            };
            _applicationContext.Add(p);
        }

        _applicationContext.SaveChanges();

        return Content("20 mahsool ezafe shod");
    }

    public IActionResult Details(int productId)
    {
        var product = _applicationContext.Products.FirstOrDefault(x => x.Id == productId);

        // if (product == null)
        //     return RedirectToAction("Page404","Product");

        var vm = new ProductViewModel()
        {
            Id=product.Id,
            Rate = product.Rate,
            Description = product.Description,
            Price = product.Price,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Quantity = product.Quantity,
            Brand = product.Brand,
        };
        
        return View(vm);
    }

    public IActionResult Page404()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult AddProduct(ProductViewModel viewModel)
    {

        if (ModelState.IsValid)
        {

            var product = new Product()
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Brand = viewModel.Brand,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity,
                Rate = viewModel.Rate,
                CategoryId = 1,
            };
            
            _applicationContext.Add(product);
            _applicationContext.SaveChanges();
            return RedirectToAction("AddProduct");
        }

        return View(viewModel);
    }
}