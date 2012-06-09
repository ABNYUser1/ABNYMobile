using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABNYMobile.Models
{
    public interface IRepository
    {
        IEnumerable<Member> GetMembers(string startsWith = null, int? skip = null, int? take = null);
        IEnumerable<Person> GetPeople(string startsWith = null, int? skip = null, int? take = null);
        
        IEnumerable<Event> GetEvents(string startsWith = null, DateTime? eventDate = null);

        IEnumerable<Attendee> GetEventAttendees(int eventId);
    }
}
