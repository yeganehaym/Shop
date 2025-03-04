using System.Security.Claims;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Shop2.Database;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Controllers;

public class UserController : Controller
{
    private IMapper _mapper;
    private ApplicationContext _context;

    public UserController(IMapper mapper, ApplicationContext context)
    {
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
   public IActionResult Signup()
   {
      return View();
   }
   
   [HttpPost]
   public IActionResult Signup(UserViewModel viewModel)
   {

      if (ModelState.IsValid)
       {
           var user = _mapper.Map<Entities.User>(viewModel);

           var exists = _context.Users.Select(u => new
               {
                   Email=_context.Users.Any(x=>x.Email==user.Email),
                   Mobile=_context.Users.Any(x=>x.MobileNumber==user.MobileNumber),
                   NationalCode=_context.Users.Any(x=>x.NationalCode==user.NationalCode),
                   Username=_context.Users.Any(x=>x.Username==user.Username),
               })
               .FirstOrDefault();


           if (exists != null)
           {
               if (exists.Email)
               {
                   ModelState.AddModelError("Email","ایمیل تکراری است");
               }

               if (exists.Mobile)
               {
                   ModelState.AddModelError("MobileNumber","شماره همراه تکراری است");
               }
           
               if (exists.Username)
               {
                   ModelState.AddModelError("Username","نام کاربری تکراری است");
               }
           
               if (exists.NationalCode)
               {
                   ModelState.AddModelError("Warning","شماره کد ملی تکراری است");
               }

               if (exists.Mobile || exists.Email || exists.NationalCode || exists.Username)
               {
                   return View(viewModel);
               }
           }
           
           _context.Users.Add(user);
           var rows=_context.SaveChanges();

           if (rows > 0)
           {
               return RedirectToAction("Login");
           }
           ModelState.AddModelError("Save","ثبت نام با خطا مواجه شد");
       }
     
       
       return View(viewModel);
   }

   [HttpGet]
   public IActionResult Login(string returnUrl="")
   {
       var vm = new LoginViewModel()
       {
           ReturnUrl = returnUrl
       };


       return View(vm);
   }

   public IActionResult SetBags()
   {
       ViewBag.ReturnUrl = "Viewbag";
       ViewData["ReturnUrl"] = "viewdata";
       TempData["ReturnUrl"] = "tempdata";

       return RedirectToAction("Login");
   }
   [HttpPost]
   public IActionResult Login(LoginViewModel viewModel)
   {
       if (ModelState.IsValid)
       {
           var usernameCheck = _context.Users.Any(x => x.Username == viewModel.Username);
           
           if (usernameCheck==false)
           {
               ModelState.AddModelError("login","نام کاربری مورد نظر یافت نشد");
               return View(viewModel);
           }
           
           var hashedPassword = viewModel.Password.Hash();
           var user = _context.Users.FirstOrDefault(x => x.Username == viewModel.Username && x.Password == hashedPassword);
           if (user == null)
           {
               ModelState.AddModelError("login"," کلمه عبور صحیح نیست");
               return View(viewModel);
           }
           
           //Login
           var claim_name = new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName);
           var claim_id = new Claim(ClaimTypes.NameIdentifier, user.Id.ToString());
           var claim_username = new Claim(ClaimTypes.GivenName, user.Username);
           var claim_role = new Claim(ClaimTypes.Role, "ADD");

           var claims = new List<Claim>();
           claims.Add(claim_name);
           claims.Add(claim_id);
           claims.Add(claim_username);
           claims.Add(claim_role);
           
           
           var claimsIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
           var claimPrincipals = new ClaimsPrincipal(claimsIdentity);

           HttpContext.SignInAsync(claimPrincipals);
           

           if (!string.IsNullOrEmpty(viewModel.ReturnUrl))
           {
               return Redirect(viewModel.ReturnUrl);
           }
           return RedirectToAction("List", "Product");
       }

       return View(viewModel);
   }

   
   public IActionResult Logout()
   {
       HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
       return RedirectToAction("Login");
   }
   
   
   [HttpGet]
   public IActionResult Cookie()
   {
       var value = Request.Cookies["test"];
       var model = new CookieModel()
       {
           Value = value
       };
       
       Response.Cookies.Append("mycookie","myvalue");
       return View(model);
   }
   
   [HttpPost]
   public IActionResult Cookie(CookieModel model)
   {
       
       Response.Cookies.Append("test",model.Value,new CookieOptions()
       {
           Expires = DateTimeOffset.Now.AddMinutes(2),
       });
       
       return View();
   }
}