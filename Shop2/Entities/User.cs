namespace Shop2.Entities;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public bool IsMale { get; set; }
    public DateTime BirthDate { get; set; }
}