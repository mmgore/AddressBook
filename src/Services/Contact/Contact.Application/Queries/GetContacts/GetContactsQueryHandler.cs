using AutoMapper;
using Contact.Domain.AggregatesModel.ContactAggregate;
using MediatR;

namespace Contact.Application.Queries.GetContacts
{
    public class GetContactsQueryHandler : IRequestHandler<GetContactsQuery, GetAllContactViewModel>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IMapper _mapper;
        public GetContactsQueryHandler(IContactItemRepository contactItemRepository,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetAllContactViewModel> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {
            return new GetAllContactViewModel
            {
                AllContacts = _mapper.Map<IEnumerable<GetContactsDto>>(await _contactItemRepository.GetContactItems())
            };
        }
    }
}
