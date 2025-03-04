using System.ComponentModel.DataAnnotations;
using DNTPersianUtils.Core;

namespace Shop2.Models;

public class UserViewModel
{
    public string? FullName { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [ValidIranianNationalCode]
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public bool IsMale { get; set; }
    
    [ValidPersianDateTime()]
    public string BirthDate { get; set; }
    
    
    public string Username { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [ValidIranianMobileNumber]
    public string MobileNumber { get; set; }
    
    public string Password { get; set; }
    
    [Compare("Password")]
    public string RePassword { get; set; }
}