using Contact.Domain.AggregatesModel.ContactInformationAggregate;
using Contact.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public class Contact : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Firm { get; private set; }
        public IList<ContactInformation> ContactInformation { get; private set; }
        public Contact()
        {
            ContactInformation = new List<ContactInformation>();
        }

        public Contact(string firstName, string lastName, string firm)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
        }

    }
}
