using Contact.Domain.Exceptions;
using Contact.Domain.SeedWork;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public class ContactItem : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Firm { get; private set; }

        public IList<ContactInformation> ContactInformations { get; private set; }
        public ContactItem()
        {
            ContactInformations = new List<ContactInformation>();
        }

        public ContactItem(string firstName, string lastName, string firm)
        {
            Id = Guid.NewGuid();
            FirstName = !string.IsNullOrWhiteSpace(firstName) ? firstName : throw new ContactDomainException("Firstname cannot be null");
            LastName = !string.IsNullOrWhiteSpace(lastName) ? lastName : throw new ContactDomainException("Lastname cannot be null");
            Firm = !string.IsNullOrWhiteSpace(firm) ? firm : throw new ContactDomainException("Firm cannot be null");
            CreatedDate = DateTime.Now;
        }

        public static ContactItem Create(string firstName, string lastName, string firm)
        {
            return new ContactItem(firstName, lastName, firm);
        }

        public void AddContactInformation(Guid contactId,string phoneNumber, string emailAddress, string location, string content)
        {
            var contactInformation = new ContactInformation(contactId, phoneNumber, emailAddress, location, content);
            ContactInformations.Add(contactInformation);
        }

    }
}
