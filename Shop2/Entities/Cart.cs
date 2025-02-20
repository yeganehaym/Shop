namespace Shop2.Entities;

/// <summary>
/// سبد خرید
/// </summary>
public class Cart:BaseEntity
{

    public Product Product { get; set; }
    public User User { get;set; }
    
    public int Quantity { get; set; }
}