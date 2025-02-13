using Microsoft.AspNetCore.Mvc;
using Shop2.Database;
using Shop2.Entities;

namespace Shop2.Controllers;

public class DataController : Controller
{
    private ApplicationContext _context;
    public DataController(ApplicationContext context)
    {
        _context = context;
    }
    // GET
    public IActionResult Index()
    {
        var users = _context
            .Users
            //.Where(x=>x.IsMale && x.LastName.Contains("yeg"))
            .ToList();
        
        return View(users);
    }

    public IActionResult AddUser()
    {
        var user = new User()
        {
            FirstName = "ahmad",
            LastName = "badpey",
            NationalCode = "50000",
            BirthDate = DateTime.Now,
            Address = "Mashhad",
            IsMale = true
        };

        _context.Users.Add(user);

        var user2 = new User()
        {
            FirstName = "mahla",
            LastName = "ghanbari",
            BirthDate = DateTime.Now.AddYears(-18),
            Address = "tehran",
            IsMale = false,
            NationalCode = "12512000",

        };
        _context.Users.Add(user2);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}