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

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Stock != null)
            {
                Product = await _context.Stock.ToListAsync();
            }
        }
    }
}
