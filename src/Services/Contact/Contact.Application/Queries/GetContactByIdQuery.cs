using MediatR;

namespace Contact.Application.Queries
{
    public class GetContactByIdQuery : IRequest<GetContactDto>
    {
        public Guid ContactId { get; set; }
    }

    public class GetContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
    }
}
