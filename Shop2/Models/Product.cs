using System.ComponentModel.DataAnnotations;

namespace Shop2.Models;

public class Product
{
    public int Id { get; set; }
 [Required(ErrorMessage = "نام محصول الزامی است")]
 [MinLength(5,ErrorMessage = "حداقل 5 کاراکتر وارد کنید")]
 [MaxLength(20,ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "برند محصول اجباری است")]
    [MinLength(5,ErrorMessage = "حداقل 5 کاراکتر وارد کنید")]
    [MaxLength(20,ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
    public string Brand { get; set; }
    
    public int Price { get; set; }
    
    [Required()]
    
    public int Quantity { get; set; }
    public string? Description { get; set; }
    
    [Required]
    [Range(1,5,ErrorMessage = "بین یک تا 5 فقط داریم")]
    public int Rate { get; set; }
}