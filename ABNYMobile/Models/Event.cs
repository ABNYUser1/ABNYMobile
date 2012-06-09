using System;
using System.ComponentModel.DataAnnotations;

namespace ABNYMobile.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public int? MaxCapacity { get; set; }
    }
}
