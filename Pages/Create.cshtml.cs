using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using laundry.Data;

namespace laundry.Pages
{
    public class CreateModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;

        public CreateModel(laundry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Laundry Laundry { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Laundry.Created = DateTime.Now;
            Laundry.LastUpdated = DateTime.Now;
            Laundry.Owner = _context.getUser();
            Laundry.Attention = false;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Laundry.Add(Laundry);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
