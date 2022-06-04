using MediatR;

namespace Contact.Application.Commands.CreateContact
{
    public class CreateContactCommand : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Location { get; set; }
        public string Content { get; set; }
    }
}
