using MediatR;

namespace Contact.Application.Queries.GetContacts
{
    public class GetContactsQuery : IRequest<GetAllContactViewModel>
    {
    }

    public class GetContactsDto 
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Firm { get; set; }
    }

    public class GetAllContactViewModel
    {
        public IEnumerable<GetContactsDto> AllContacts { get; set; }
    }
}
