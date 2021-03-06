using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using laundry.Data;

namespace laundry.Pages
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;

        public IndexModel(laundry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Laundry> Laundry { get;set; }

        public async Task OnGetAsync()
        {
            foreach (var item in _context.Laundry)
            {
                if (DateTime.Compare(DateTime.Now, item.LastUpdated.AddHours(3.5)) > 0 && item.Status != "Done_done") {
                    item.Attention = true;
                }
            } 
            Laundry = await _context.Laundry.ToListAsync();
        }
    }
}
