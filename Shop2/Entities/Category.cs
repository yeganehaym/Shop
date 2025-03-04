namespace Shop2.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; }
    
    public Category Parent { get; set; }
    public int? ParentId { get; set; }
    
    public List<Category> Children { get; set; }
}