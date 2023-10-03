using System.ComponentModel.DataAnnotations;

namespace Eshopping.Models;

public class Client
{
    [Key] public int clientId;
    [Required] public string firstName { get; set; }
    [Required] public string lastName { get; set; }
    [Required] public string email { get; set; }
    [Required] public DateOnly dateOfBirth { get; set; }
    [Required] public string code { get; set; }
    public Cart cart { get; set; }

}