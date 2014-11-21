using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSC440_Project.Models
{
    public class BLSOccuupationalGroup
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Code { get; set; }
        public virtual double CurrentEmployment { get; set; }
        public virtual double FutureEmployment { get; set; }
        public virtual double NumberChange { get; set; }
        public virtual double PercentChange { get; set; }
        public virtual double MedianWage { get; set; }
    }
}