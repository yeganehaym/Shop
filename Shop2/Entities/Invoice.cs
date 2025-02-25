namespace Shop2.Entities;

public class Invoice:BaseEntity
{
    public User User { get; set; }
    public DateTime InvoiceDateTime { get; set; }
    public int TotalPrice { get; set; }
    public string Address { get; set; }
    public int Discount { get; set; }
    
    public List<InvoiceItem> InvoiceItems { get; set; }
}