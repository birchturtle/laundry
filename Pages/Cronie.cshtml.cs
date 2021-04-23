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
    public class CronieModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;

        public CronieModel(laundry.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Laundry> Laundry { get;set; }
        public async Task OnGetAsync() {
            foreach (var item in _context.Laundry)
            {
                if (DateTime.Compare(DateTime.Now, item.LastUpdated.AddHours(3.5)) > 0 && item.Status != "Done_done") {
                    _context.Laundry.Update(item);
                    item.Attention = true;
                    _context.SaveChanges();
                }
            }
            IEnumerable<laundry.Data.Laundry> NeedsAttention = 
                from wash in _context.Laundry
                where wash.Attention == true
                select wash;

            if (NeedsAttention.Any())
            {
                foreach(var wash in NeedsAttention) {
                Console.WriteLine(wash.Status);
                }
            }
        
            Laundry = await _context.Laundry.ToListAsync();
        }
    }
}