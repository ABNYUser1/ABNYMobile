using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace ABNYMobile.Models
{
    public class Attendee
    {
        [Key]
        public int Id { get; set; }

        public int PersonId { get; set; }

        public Person AssociatedPerson { get; set; }

        public int EventId { get; set; }

        public Event AssociatedEvent { get; set; }
    }
}
