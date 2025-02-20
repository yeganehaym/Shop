namespace Shop2.Entities;

public class InvoiceItem:BaseEntity
{

    public Product Product { get; set; }
    public Invoice Invoice { get; set; }
    
    public int Quantity { get; set; }
    
    public int Price { get; set; }
    
    public int Discount { get; set; }
}