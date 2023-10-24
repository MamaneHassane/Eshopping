using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Eshopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Eshopping.Pages.ProductMaster
{
    public class CartPageModel : PageModel
    {
        private readonly Eshopping.DAL.AppDbContext _context;
        public List<Product> CartProducts { get; set; } = new List<Product>();
        private Cart theCart { get; set; } = new Cart();
        public CartPageModel(Eshopping.DAL.AppDbContext context)
        {
            _context = context;
        }
       
        public void OnGet(int CartIdSend)
        {
            theCart = _context.Carts.OrderByDescending(c => c.CartId).FirstOrDefault(c => c.CartId == CartIdSend);

            if (theCart != null && !string.IsNullOrWhiteSpace(theCart.CartProductIds))
            {
                Console.WriteLine("A cart is found");
                var productIds = JsonSerializer.Deserialize<List<int>>(theCart.CartProductIds);
                CartProducts = GetProductsFromDatabase(productIds);
            }
        }

        private List<Product> GetProductsFromDatabase(List<int> productIds)
        {
            if (productIds == null || !productIds.Any())
            {
                return new List<Product>();
            }

            var cartProducts = _context.Stock.Where(p => productIds.Contains(p.Id)).ToList();
            return cartProducts;
        }
    }
}