using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eshopping.Models;

public class Cart
{
    [Key] public int cartId { get; set; }
    [ForeignKey("client")] public int clientId { get; set; }
    public Client client { get; set; }
    public ICollection<Product> products { get; set; }
}