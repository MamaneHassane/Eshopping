using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Eshopping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Eshopping.Pages.ProductMaster
{
    public class CartPageModel : PageModel
    {
        private readonly Eshopping.DAL.AppDbContext _context;
        public List<Product> CartProducts { get; set; } = new List<Product>();
        private Cart cart;
        public CartPageModel(Eshopping.DAL.AppDbContext context)
        {
            _context = context;
            if(CartProducts==null) CartProducts = new List<Product>();
        }

         
        public void OnGet(int theProductId)
        {
            var foundProduct = _context.Stock.Find(theProductId);
            if(CartProducts == null) CartProducts = new List<Product>();
            CartProducts.Add(foundProduct);
            _context.SaveChanges();
        }

        public async Task<IActionResult> onGetAsync()
        {
            CartProducts = await _context.Carts.Find(g=>);
            return Page();
        }
    }
}