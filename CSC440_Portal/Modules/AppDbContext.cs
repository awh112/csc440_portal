using CSC440_Project.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CSC440_Project.Modules
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<OccupationalGroup> OccupationalGroups { get; set; }
        public DbSet<DetailedOccupation> DetailedOccupations { get; set; }

        public AppDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static AppDbContext Create()
        {
            return new AppDbContext();
        }
    }
}