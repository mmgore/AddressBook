﻿using Contact.Domain.Exceptions;
using Contact.Domain.SeedWork;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public class ContactInformation : Entity
    {
        public Guid ContactId { get; private set; }
        public string PhoneNumber { get; private set; }
        public string EmailAddress { get; private set; }
        public string Location { get; private set; }
        public string Content { get; private set; }
        
        public ContactInformation(Guid contactId, string phoneNumber, string emailAddress, string location, string content)
        {
            ContactId = contactId;
            PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : throw new ContactDomainException("PhoneNumber cannot be null");
            EmailAddress = !string.IsNullOrWhiteSpace(emailAddress) ? emailAddress : throw new ContactDomainException("EmailAddress cannot be null");
            Location = !string.IsNullOrWhiteSpace(location) ? location : throw new ContactDomainException("Location cannot be null");
            Content = !string.IsNullOrWhiteSpace(content) ? content : throw new ContactDomainException("Content cannot be null");
        }

        public static ContactInformation Create(Guid contactId, string phoneNumber, string emailAddress, string location, string content)
        {
            return new ContactInformation(contactId, phoneNumber, emailAddress, location, content);
        }
    }
}
