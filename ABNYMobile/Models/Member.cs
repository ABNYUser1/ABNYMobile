using System;
using System.ComponentModel.DataAnnotations;

namespace ABNYMobile.Models
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        
        public bool IsIndividual { get; set; }
        public bool IsGovernmentAgency { get; set; }

        [Required]
        public string PrimaryContact { get; set; }
        public string PrimaryPhone { get; set; }

        public string Tags { get; set; }

        public double AnnualDuesAmount { get; set; }
        public DateTime? LastPaid { get; set; }

        public double OutstandingBalance { get; set; }

        public DateTime MemberSince { get; set; }
    }
}
