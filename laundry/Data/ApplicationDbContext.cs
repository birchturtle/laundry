using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using laundry.Data;

namespace laundry.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        private readonly IHttpContextAccessor _ctxAcc;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor ctxAcc)
            : base(options)
        {
            _ctxAcc = ctxAcc;
        }
        public DbSet<laundry.Data.Laundry> Laundry { get; set; }

        public string getUser() {
            return _ctxAcc.HttpContext.User.Identity.Name;
        }
    }
}
