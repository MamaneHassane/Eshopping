using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eshopping.DAL;
using Eshopping.Models;

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
        public List<int> CartProductIds { get; set; } = new List<int>();

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var products = from m in _context.Stock
                select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                products = products.Where(p => p.Name.Contains(SearchString));
            }

            Product = await products.ToListAsync();
        }

        public IActionResult OnPostAddToCart(int productId)
        {
            if (CartProductIds == null)
            {
                CartProductIds = new List<int>();
            }
            CartProductIds.Add(productId);
            return RedirectToPage("/ProductMaster/CartPage", new { theProductId = productId });
        }
        public void OnGetCartPage()
        {
            var cartProducts = GetProductsFromDatabase(CartProductIds);
            ViewData["CartProducts"] = cartProducts;
        }

        private List<Product> GetProductsFromDatabase(List<int> productIds)
        {
            var cartProducts = _context.Stock.Where(p => productIds.Contains(p.Id)).ToList();
            return cartProducts;
        }

    }
}