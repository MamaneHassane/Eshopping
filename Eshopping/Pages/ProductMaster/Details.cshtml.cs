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
    public class DetailsModel : PageModel
    {
        private readonly Eshopping.DAL.AppDbContext _context;

        public DetailsModel(Eshopping.DAL.AppDbContext context)
        {
            _context = context;
        }

      public Product Product { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Stock == null)
            {
                return NotFound();
            }

            var product = await _context.Stock.FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else 
            {
                Product = product;
            }
            return Page();
        }
    }
}
