using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Eshopping.Models;

public class Cart
{
    [Key] public int cardId;
    [ForeignKey("Client")]
    private Client client;
    public ICollection<Product> products { get; set; }
}