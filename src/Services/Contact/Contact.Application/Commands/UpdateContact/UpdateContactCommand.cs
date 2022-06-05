using MediatR;

namespace Contact.Application.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
    }
}
