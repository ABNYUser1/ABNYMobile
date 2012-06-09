using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABNYMobile.Models
{
    public class MockRepository : IRepository
    {
        private List<Member> _mock_membersList = new List<Member>();
        private List<Person> _mock_peopleList = new List<Person>();
        private List<Event> _mock_eventsList = new List<Event>();
        private List<Attendee> _mock_attendeesList = new List<Attendee>();

        public IEnumerable<Member> GetMembers(string startsWith = null, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();   
        }

        public IEnumerable<Person> GetPeople(string startsWith = null, int? skip = null, int? take = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetEvents(string startsWith = null, DateTime? eventDate = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Attendee> GetEventAttendees(int eventId)
        {
            throw new NotImplementedException();
        }
    }
}