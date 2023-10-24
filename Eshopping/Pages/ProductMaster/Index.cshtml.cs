using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eshopping.DAL;
using Eshopping.Models;
using Humanizer;

namespace Eshopping.Pages.ProductMaster
{
    public class IndexModel : PageModel
    {
        private readonly Eshopping.DAL.AppDbContext _context;

        public IndexModel(Eshopping.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        public Cart Cart { get; set; } = new Cart();
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            if (Product == null)
            {
                var products = from m in _context.Stock
                    select m;

                if (!string.IsNullOrEmpty(SearchString))
                {
                    products = products.Where(p => p.Name.Contains(SearchString));
                }

                Product = await products.ToListAsync();
            }
        }
        
        public IActionResult OnPostAddToCart(int productId)
        {
            if (Cart == null)
            {
                Cart = new Cart();
            }
            Cart.AddProductById(productId);
            var existingCart = _context.Carts.OrderByDescending(c => c.CartId).FirstOrDefault();
            if (existingCart != null)
            {
               existingCart.AddProductById(productId);
                _context.Carts.Update(existingCart);
            }
            else
            {
                _context.Carts.Add(Cart);
            }
            _context.SaveChanges();
            return RedirectToPage("Index");
        }

        public async Task<IActionResult> OnPostRedirectToCart()
        {
           
            var existingCart = _context.Carts.OrderByDescending(c => c.CartId).FirstOrDefault();
            _context.Carts.Update(existingCart);
            await _context.SaveChangesAsync();
            return RedirectToPage("CartPage", new { CartIdSend = existingCart.CartId });
        }
    }
}