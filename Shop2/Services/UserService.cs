using Shop2.Database;
using Shop2.Entities;
using Shop2.Models;

namespace Shop2.Services;

public class UserService
{
    private ApplicationContext _context;

    public UserService(ApplicationContext context)
    {
        _context = context;
    }

    public User Login(string username, string password)
    {
        var hashPassword = password.Hash();
        return _context.Users.FirstOrDefault(x => x.Username == username && x.Password == hashPassword);
    }

    public UserExistence CheckExistence(User user)
    {
        var exists = _context.Users.Select(u => new UserExistence
            {
                Email=_context.Users.Any(x=>x.Email==user.Email),
                Mobile=_context.Users.Any(x=>x.MobileNumber==user.MobileNumber),
                NationalCode=_context.Users.Any(x=>x.NationalCode==user.NationalCode),
                Username=_context.Users.Any(x=>x.Username==user.Username),
            })
            .FirstOrDefault();

        return exists;
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
    }
}