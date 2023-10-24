using System.ComponentModel.DataAnnotations;

namespace Eshopping.Models;

[Serializable]
public class Client
{
    [Key] public int clientId { get; set; }
    [Required] public string firstName { get; set; }
    [Required] public string lastName { get; set; }
    [Required] public string email { get; set; }
    [Required] public DateOnly dateOfBirth { get; set; }
    [Required] public string code { get; set; }
    public Cart? cart { get; set; }
}