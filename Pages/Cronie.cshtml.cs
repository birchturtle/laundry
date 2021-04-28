using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;
using laundry.Data;

namespace laundry.Pages
{
    public class CronieModel : PageModel
    {
        private readonly laundry.Data.ApplicationDbContext _context;
        public IConfiguration Configuration { get; }
        public CronieModel(laundry.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            Configuration = configuration;
            _context = context;
            _userManager = userManager;
        }
        public IList<Laundry> Laundry { get;set; }
        private UserManager<IdentityUser> _userManager  { get; set;}
        public async Task OnGetAsync() {
            IConfigurationSection SMTPSettings = Configuration.GetSection("MailSettings");
            foreach (var item in _context.Laundry)
            {
                if (DateTime.Compare(DateTime.Now, item.LastUpdated.AddHours(3.5)) > 0 && item.Status != "Done_done") {
                    _context.Laundry.Update(item);
                    item.Attention = true;
                    _context.SaveChanges();
                }
                if(DateTime.Compare(DateTime.Now, item.LastUpdated.AddMonths(2)) > 0 && item.Status == "Done_done") {
                    _context.Laundry.Remove(item);
                    _context.SaveChanges();
                }
            }
            IEnumerable<laundry.Data.Laundry> NeedsAttention = 
                from wash in _context.Laundry
                where wash.Attention == true
                select wash;
            if (NeedsAttention.Any())
            {
                var message = new MimeMessage ();
                message.From.Add (new MailboxAddress ("Our Laundromat", SMTPSettings.GetValue<String>("SMTPUser")));
                foreach(var user in _userManager.Users) {
                    message.To.Add (new MailboxAddress (user.Email, user.Email));
                }
                message.Subject = "News from the laundromat!";
                String content = "Hi there!\nJust letting you know that the following washes need your attention:\n\n";
                foreach (var wash in NeedsAttention) {
                    content += wash.TypeOfWash + "\nadded by " + wash.Owner + "\non " + wash.Created + "\nand which was last updated " + wash.LastUpdated + "\n\n";
                    if (wash.Comment != "") {
                        content += "\nPlease note:\n" + wash.Comment;
                    }
                }
                content += "\nThat's all, folks!";

                message.Body = new TextPart ("plain") {
                    Text = content
                };
                using (var client = new SmtpClient ()) {
                    client.Connect (SMTPSettings.GetValue<String>("SMTPHost"), 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate (SMTPSettings.GetValue<String>("SMTPUser"), SMTPSettings.GetValue<String>("SMTPPass"));
                    client.Send (message);
                    client.Disconnect (true);
                }
            }
            Laundry = await _context.Laundry.ToListAsync();
        }
    }
}