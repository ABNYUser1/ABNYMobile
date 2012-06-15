using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

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

        public List<Attendee> Attendees { get; set; }
    }
}
