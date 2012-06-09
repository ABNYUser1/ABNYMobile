using System.ComponentModel.DataAnnotations;

namespace ABNYMobile.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        public int? MemberId { get; set; }

        public Member MemberWith { get; set; }
    }
}
