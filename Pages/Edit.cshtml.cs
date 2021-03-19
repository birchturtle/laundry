using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using laundry.Data;

namespace laundry.Pages
{
    public class EditModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;

        public EditModel(laundry.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Laundry.LastUpdated = DateTime.Now;

            _context.Attach(Laundry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LaundryExists(Laundry.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LaundryExists(int id)
        {
            return _context.Laundry.Any(e => e.ID == id);
        }
    }
}
