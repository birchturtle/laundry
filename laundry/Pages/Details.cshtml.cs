using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laundry.Data;

namespace laundry.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;

        public DetailsModel(laundry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Laundry Laundry { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Laundry = await _context.Laundry.FirstOrDefaultAsync(m => m.ID == id);

            if (Laundry == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
