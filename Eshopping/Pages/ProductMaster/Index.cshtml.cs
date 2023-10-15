using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Eshopping.DAL;
using Eshopping.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Eshopping.Pages.ProductMaster
{
    public class IndexModel : PageModel
    {
        private readonly Eshopping.DAL.AppDbContext _context;

        public IndexModel(Eshopping.DAL.AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string ? SearchString { get; set; }
        public SelectList ? SearchedProducts { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? ProductName { get; set; }

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
    }
}
