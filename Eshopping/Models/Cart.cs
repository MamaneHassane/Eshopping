using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eshopping.Models;

[Serializable]
public class Cart
{
    [Key] public int cartId { get; set; }
    [ForeignKey("client")] public int? clientId { get; set; }
    public Client? client { get; set; }
    public List<Product>? Products { get; set; } = new List<Product>();

    public void AddProduct(Product p)
    {
        Products ??= new List<Product>();
        Products.Add(p);
    }
}