using Microsoft.AspNetCore.Mvc;
using Shop2.Database;
using Shop2.Entities;
using Shop2.Services;

namespace Shop2.Controllers;

[Route("/cats/{action}/{id?}")]
public class ProductCategoryController : Controller
{
    private CategoryService _categoryService;
    private ApplicationContext _context;

    public ProductCategoryController(CategoryService categoryService, ApplicationContext context)
    {
        _categoryService = categoryService;
        _context = context;
    }

    // GET
    public async Task<IActionResult> Index()
    {
        var cats = await _categoryService.GetFamily(1);
        
        return Content("Count:" + cats.Count);
    }
}