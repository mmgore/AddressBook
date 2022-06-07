using MediatR;

namespace Contact.Application.Queries.GetContactById
{
    public class GetContactByIdQuery : IRequest<GetContactDto>
    {
        public Guid ContactItemId { get; set; }
    }

    public class GetContactDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
    }
}
