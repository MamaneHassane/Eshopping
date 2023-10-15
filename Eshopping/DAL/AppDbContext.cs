using Eshopping.Models;
using Microsoft.EntityFrameworkCore;


namespace Eshopping.DAL;

public class AppDbContext: DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) {}
    public virtual DbSet<Product> Stock{ get; set; }
    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Cart> Carts { get; set; }
}