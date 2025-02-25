namespace Shop2.Entities;

public class User:BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public bool IsMale { get; set; }
    public DateTime BirthDate { get; set; }
    
    
    public string Username { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    
    public string Password { get; set; }
    
}