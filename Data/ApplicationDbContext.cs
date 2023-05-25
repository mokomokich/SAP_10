using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAP_10.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAP_10.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Sotrydnik> Sotrydnik { get; set; }
        public DbSet<Vacation> Vacation { get; set; }
        //public DbSet<Spisanies> Spisanies { get; set; }
    }
}
