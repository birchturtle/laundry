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
    public class DeleteModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;

        public DeleteModel(laundry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Laundry = await _context.Laundry.FindAsync(id);

            if (Laundry != null)
            {
                _context.Laundry.Remove(Laundry);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
