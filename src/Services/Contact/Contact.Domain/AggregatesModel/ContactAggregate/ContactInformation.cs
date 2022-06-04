using Contact.Domain.Exceptions;
using Contact.Domain.SeedWork;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public class ContactInformation : Entity
    {
        public Guid ContactId { get; set; }
        public InformationType InformationType { get; private set; }
        public string Content { get; private set; }

        public ContactInformation(Guid contactId, string phoneNumber, string emailAddress, string location, string content)
        {
            ContactId = contactId;
            InformationType = new InformationType(phoneNumber, emailAddress, location);
            Content = !string.IsNullOrWhiteSpace(content) ? content : throw new ContactDomainException("Content cannot be null");
        }

        
    }
}
