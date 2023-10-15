using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace Eshopping.Models;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key] public int Id { get; set; }
    [Required] [DisplayName("ProductName")] 
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }	
    public string Description { get; set; }
    public string ImageUrl { get; set; }  
    [Required]
    public int Quantity { get; set; }

    public ICollection<Cart> carts { get; set; }
    
}