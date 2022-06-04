using Contact.Domain.Exceptions;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public class InformationType
    {
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Location { get; private set; }

        public InformationType(string phoneNumber, string emailAddress, string location)
        {
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ContactDomainException("PhoneNumber cannot be null");
            EmailAddress = !string.IsNullOrWhiteSpace(emailAddress) ? emailAddress : throw new ContactDomainException("EmailAddress cannot be null"); ;
            Location = !string.IsNullOrWhiteSpace(location) ? location : throw new ContactDomainException("Location cannot be null"); ;    
        }
    }
}
