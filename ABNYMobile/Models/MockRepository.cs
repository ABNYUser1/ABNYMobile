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

        public MockRepository()
        {
            AddMockMembers();
            AddMockPeople();
            AddMockEvents();
            AddMockAttendees();
        }

        #region Fill Repository with Mock Data
        private void AddMockAttendees()
        {
            var last_id = 1;
            // Every one is going!
            var ev = _mock_eventsList.First();
            _mock_peopleList.ForEach(
                p => _mock_attendeesList.Add(new Attendee { Id = (last_id++), EventId = ev.Id, AssociatedEvent = ev, PersonId = p.Id, AssociatedPerson = p, IsHere = false })
                );
        }

        private void AddMockEvents()
        {
            var last_id = 1;
            #region Quick Add Function
            Func<string, string, DateTime, int?, List<Attendee>, Event> _quickAdd = (title, desc, dt, capacity, attendees) =>
            {
                var e = new Event { Id = (last_id++), Title = title, Description = desc, EventDate = dt, MaxCapacity = capacity, Attendees = attendees };
                return e;
            };
            #endregion

            _mock_eventsList.Add(_quickAdd("Event 1", "This is a sample Event", new DateTime(2012, 12, 16), 100, _mock_attendeesList));
        }

        private void AddMockPeople()
        {
            int last_id = 1;
            #region Quick Add Function 
            Func<string, string, string, Member, Person> _quickAdd = (first, last, eml, member) => {
                var p = new Person { Id = (last_id++), FirstName = first, LastName = last, EmailAddress = eml };
                if (member != null)
                {
                    p.MemberWith = member;
                    p.MemberId = member.Id;
                }
                return p;
            };
            #endregion

            _mock_peopleList.Add(_quickAdd("Glenn", "Ferrie", "glenn.ferrie@fake.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Company 1"))));
            _mock_peopleList.Add(_quickAdd("Kathleen", "Ferrie", "kathleen.ferrie@fake.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Company 1"))));
            _mock_peopleList.Add(_quickAdd("Edith", "Ferrie", "edith.ferrie@fake.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Company 1"))));
            _mock_peopleList.Add(_quickAdd("Scott", "Ferrie", "scott.ferrie@fake.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Company 1"))));

            _mock_peopleList.Add(_quickAdd("Greg", "Steinberg", "steinberg@sd.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Something Digital"))));
            _mock_peopleList.Add(_quickAdd("Mike", "Savino", "savino@sd.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Something Digital"))));
            _mock_peopleList.Add(_quickAdd("Jon", "Klonsky", "klonsky@sd.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Something Digital"))));
            _mock_peopleList.Add(_quickAdd("Jon", "Tudhope", "tudhope@sd.com", _mock_membersList.Single(q => q.CompanyName.StartsWith("Something Digital"))));

            _mock_peopleList.Add(_quickAdd("ABNY 1", "User 1", "abnyuser1@abny.org", _mock_membersList.Single(q => q.CompanyName.StartsWith("ABNY"))));
            _mock_peopleList.Add(_quickAdd("ABNY 2", "User 2", "abnyuser2@abny.org", _mock_membersList.Single(q => q.CompanyName.StartsWith("ABNY"))));
            _mock_peopleList.Add(_quickAdd("ABNY 3", "User 3", "abnyuser3@abny.org", _mock_membersList.Single(q => q.CompanyName.StartsWith("ABNY"))));
            _mock_peopleList.Add(_quickAdd("ABNY 4", "User 4", "abnyuser4@abny.org", _mock_membersList.Single(q => q.CompanyName.StartsWith("ABNY"))));
            _mock_peopleList.Add(_quickAdd("ABNY 5", "User 5", "abnyuser5@abny.org", _mock_membersList.Single(q => q.CompanyName.StartsWith("ABNY"))));
            _mock_peopleList.Add(_quickAdd("ABNY 6", "User 6", "abnyuser6@abny.org", _mock_membersList.Single(q => q.CompanyName.StartsWith("ABNY"))));

            // US Federal Gov't
            _mock_peopleList.Add(_quickAdd("Barak", "Obama", "obama@us.gov", _mock_membersList.Single(q => q.CompanyName.StartsWith("US Federal Gov't"))));
            _mock_peopleList.Add(_quickAdd("User", "1", "user1@us.gov", _mock_membersList.Single(q => q.CompanyName.StartsWith("US Federal Gov't"))));
            _mock_peopleList.Add(_quickAdd("User", "2", "user2@us.gov", _mock_membersList.Single(q => q.CompanyName.StartsWith("US Federal Gov't"))));
            _mock_peopleList.Add(_quickAdd("User", "3", "user3@us.gov", _mock_membersList.Single(q => q.CompanyName.StartsWith("US Federal Gov't"))));

        }

        private void AddMockMembers()
        {
            int last_id = 1;
            #region Quick Add Function
            Func<string, string, bool, bool, Member> _quickAdd = (name, contact, isCompany, isGovt) => {
                var m = new Member { Id = (last_id++), CompanyName = name, PrimaryContact = contact, MemberSince = new DateTime(2010, 1, 1) };
                if (isGovt)
                {
                    m.IsGovernmentAgency = true;
                    m.AnnualDuesAmount = 0.00;
                }
                else
                {
                    if (isCompany)
                    {
                        m.IsIndividual = false;
                        m.AnnualDuesAmount = 1000.00;
                    }
                    else
                    {
                        m.IsIndividual = true;
                        m.AnnualDuesAmount = 500.00;
                    }
                }
                return m;
            };
            #endregion

            _mock_membersList.Add(_quickAdd("Company 1", "Glenn Ferrie", true, false));
            _mock_membersList.Add(_quickAdd("Something Digital", "Greg Steinberg", true, false));
            _mock_membersList.Add(_quickAdd("ABNY", "ABNY User1", true, false));
            _mock_membersList.Add(_quickAdd("City of New York", "Mike Bloomberg", false, false));
            _mock_membersList.Add(_quickAdd("US Federal Gov't", "Barak Obama", true, true));
        }
        #endregion

        public IEnumerable<Member> GetMembers(string startsWith = null, int? skip = null, int? take = null)
        {
            IEnumerable<Member> set = null;
            if (startsWith == null)
                set = _mock_membersList;
            else
                set = _mock_membersList.Where(q => q.CompanyName.StartsWith(startsWith));

            if (skip != null && skip.HasValue) set = set.Skip(skip.Value);
            if (take != null && take.HasValue) set = set.Take(take.Value);

            return set;
        }

        public IEnumerable<Person> GetPeople(string startsWith = null, int? skip = null, int? take = null)
        {
            IEnumerable<Person> set = null;
            if (startsWith == null)
                set = _mock_peopleList;
            else
                set = _mock_peopleList.Where(q => q.LastName.StartsWith(startsWith) || q.FirstName.StartsWith(startsWith));

            if (skip != null && skip.HasValue) set = set.Skip(skip.Value);
            if (take != null && take.HasValue) set = set.Take(take.Value);

            return set;
        }

        public IEnumerable<Event> GetEvents(string startsWith = null, DateTime? eventDate = null)
        {
            IEnumerable<Event> set = null;
            if (startsWith == null)
                set = _mock_eventsList;
            else
                set = _mock_eventsList.Where(q => q.Title.StartsWith(startsWith));

            if (eventDate != null && eventDate.HasValue) set = set.Where(q => q.EventDate == eventDate.Value);

            return set;
        }

        public Event GetEvent(int Id)
        {
            return _mock_eventsList.First(q => q.Id == Id);
        }

        public IEnumerable<Attendee> GetEventAttendees(int eventId)
        {
            IEnumerable<Attendee> set = _mock_attendeesList.Where(q => q.EventId == eventId);

            return set;
        }
    }
}