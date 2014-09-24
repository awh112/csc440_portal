using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CSC440_Project.Models
{
    public class DetailedOccupation
    {
        public virtual int Id { get; set; }
        public virtual string OccupationalCode { get; set; }
        public virtual string Title { get; set; }
        public virtual int OccupationalGroupId { get; set; }
        [ForeignKey("OccupationalGroupId")]
        public virtual OccupationalGroup OccupationalGroup { get; set; }
        public virtual int CurrentEmployment { get; set; }
        public virtual int FutureEmployment { get; set; }
        public virtual int NumberChange { get; set; }
        public virtual double PercentageChange { get; set; }
        public virtual int OpeningsAndReplacementsGrowth { get; set; }
    }
}