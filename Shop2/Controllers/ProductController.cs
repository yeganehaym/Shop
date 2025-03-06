using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop2.Database;
using Shop2.Entities;
using Shop2.Models;
using Shop2.Services;

namespace Shop2.Controllers;

public class ProductController : Controller
{
    private ApplicationContext _applicationContext;
    private IMapper _mapper;
    private ProductService _productService;
    private IWebHostEnvironment _environment;
    public ProductController(ApplicationContext applicationContext,IMapper mapper, ProductService productService, IWebHostEnvironment environment)
    {
        _applicationContext = applicationContext;
        _mapper = mapper;
        _productService = productService;
        _environment = environment;
    }


    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult List(int page=1)
    {
        var products = _productService.GetProducts(page);
        var count = _productService.GetProductCount();
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

      //  var list = products.Adapt<List<ProductViewModel>>();
      var list = _mapper.Map<List<ProductViewModel>>(products);
        
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
        var product = _productService.GetProductById(productId);

        // if (product == null)
        //     return RedirectToAction("Page404","Product");

        /*var vm = new ProductViewModel()
        {
            Id=product.Id,
            Rate = product.Rate,
            Description = product.Description,
            Price = product.Price,
            Name = product.Name,
            CategoryId = product.CategoryId,
            Quantity = product.Quantity,
            Brand = product.Brand,
        };*/

        var vm = _mapper.Map<ProductViewModel>(product);
        
        return View(vm);
    }

    public IActionResult Page404()
    {
        return View();
    }

    [Authorize(Roles = "ADD")]
    [HttpGet]
    public IActionResult AddProduct()
    {
        return View();
    }
    
    [Authorize(Roles = "ADD")]
    [HttpPost]
    public IActionResult AddProduct(ProductViewModel viewModel)
    {

        if (ModelState.IsValid)
        {

            var product = _mapper.Map<Product>(viewModel);

            if (viewModel.Image != null && viewModel.Image.Length > 0)
            {
                var ms = new MemoryStream();
                viewModel.Image.CopyTo(ms);
                ms.Seek(0,SeekOrigin.Begin);
                var bytes=ms.ToArray();
                
                
                //خیره بایتی در دیتابیس
                product.ImageBytes = bytes;
                
                //ذخیره به صورت فایل سیستم

                var wwwroot = _environment.ContentRootPath;
                var path = "images/products/";
                var now = DateTime.Now;
                //var filename1 = $"{now.Year}-{now.Month}-{now.Day}--{now.Hour}-{now.Minute}-{now.Second}-userid.jpg";
                var fileName = Guid.NewGuid().ToString().Substring(0, 10) + ".jpg";

                var fullPath = Path.Combine(wwwroot, path);
                var fullName = Path.Combine(fullPath, fileName);

                Directory.CreateDirectory(fullPath);
                System.IO.File.WriteAllBytes(fullName,bytes);
                product.ImageName = fileName;
            }

            product.CategoryId = 1;
            _productService.AddProduct(product);
            _applicationContext.SaveChanges();
            return RedirectToAction("AddProduct");
        }

        return View(viewModel);
    }

    public IActionResult ShowImage(int productId)
    {
        var product = _productService.GetProductById(productId);
        
        var wwwroot = _environment.ContentRootPath;
        var path = "images/products/";
        var name = product.ImageName;

        if (name == null)
            return new EmptyResult();

        var fullName = Path.Combine(wwwroot, path, name);
        if (!System.IO.File.Exists(fullName))
            return new EmptyResult();
        

        var bytes = System.IO.File.ReadAllBytes(fullName);

        return File(bytes, "images/jpg");

    }
}