using MediatR;

namespace Contact.Application.Commands.CreateContactInfo
{
    public class CreateContactInfoCommand : IRequest
    {
        public Guid ContactId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}
