using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC440_Project.Models
{
    public class OccupationalGroup
    {
        public virtual int Id { get; set; }
        public virtual string OccupationalCode { get; set; }
        public virtual string GroupName { get; set; }
        public virtual int CurrentEmploymentNumber { get; set; }
        public virtual int FutureEmploymentNumber { get; set; }
        public virtual double PercentChange { get; set; }
        public virtual int NumberChange { get; set; }
        public virtual int Replacements { get; set; }
        public virtual int Openings { get; set; }
        public virtual int MedianAnnualWage { get; set; }
    }
}