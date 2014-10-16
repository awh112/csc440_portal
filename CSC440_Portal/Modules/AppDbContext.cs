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

        public void SaveOccupationalGroup(OccupationalGroup group)
        {
            if (group.Id == 0)
            {
                //create one to use below
            }

            var dbGroup = OccupationalGroups.Find(group.Id);

            if (dbGroup != null)
            {
                dbGroup.OccupationalCode = group.OccupationalCode;
                dbGroup.GroupName = group.GroupName;
                dbGroup.CurrentEmploymentNumber = group.CurrentEmploymentNumber;
                dbGroup.FutureEmploymentNumber = group.FutureEmploymentNumber;
                dbGroup.PercentChange = group.PercentChange;
                dbGroup.NumberChange = group.NumberChange;
                dbGroup.Replacements = group.Replacements;
                dbGroup.Openings = group.Openings;
                dbGroup.MedianAnnualWage = group.MedianAnnualWage;
            }

            SaveChanges();
        }

        public OccupationalGroup DeleteOccupationalGroup(int id)
        {
            var dbEntry = OccupationalGroups.Find(id);

            if (dbEntry != null)
            {
                OccupationalGroups.Remove(dbEntry);
                SaveChanges();
            }

            return dbEntry;
        }

        public void SaveDetailedOccupation(DetailedOccupation occupation)
        {
            if (occupation.Id == 0)
            {
                //create one to use below
            }

            var dbOccupation = DetailedOccupations.Find(occupation.Id);

            if (dbOccupation != null)
            {
                dbOccupation.OccupationalCode = occupation.OccupationalCode;
                dbOccupation.Title = occupation.Title;
                dbOccupation.CurrentEmployment = occupation.CurrentEmployment;
                dbOccupation.FutureEmployment = occupation.FutureEmployment;
                dbOccupation.NumberChange = occupation.NumberChange;
                dbOccupation.PercentageChange = occupation.PercentageChange;
                dbOccupation.OpeningsAndReplacementsGrowth = occupation.OpeningsAndReplacementsGrowth;
            }

            SaveChanges();
        }

        public DetailedOccupation DeleteDetailedOccupation(int id)
        {
            var dbEntry = DetailedOccupations.Find(id);

            if(dbEntry != null)
            {
                DetailedOccupations.Remove(dbEntry);
                SaveChanges();
            }

            return dbEntry;
        }
    }
}