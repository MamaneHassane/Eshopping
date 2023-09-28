using System.ComponentModel;

namespace Eshopping.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    public int Id { get; set; }
    [Required]
    [DisplayName("ProductName")] 
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }	
    public string Description { get; set; }
    public string ImageUrl { get; set; }  
    public int Quantity { get; set; }
}