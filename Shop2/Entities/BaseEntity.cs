using System.ComponentModel.DataAnnotations;

namespace Shop2.Entities;

public class BaseEntity
{
    public BaseEntity()
    {
        CreationDateTime = DateTime.Now;
    }
    
    public int Id { get; set; }
    
    public DateTime CreationDateTime { get; set; }
    public DateTime? ModificationDateTime { get; set; }
    
}