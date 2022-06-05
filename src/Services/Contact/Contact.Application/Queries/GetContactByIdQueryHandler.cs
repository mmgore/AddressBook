using AutoMapper;
using Contact.Application.Exceptions;
using Contact.Domain.AggregatesModel.ContactAggregate;
using MediatR;

namespace Contact.Application.Queries
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactDto>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IContactItemRepository contactItemRepository,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetContactDto> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactItemRepository.GetContactItemById(request.ContactId);

            if (contact == null)
            {
                throw new NotFoundException(nameof(ContactItem), request.ContactId);
            }

            return _mapper.Map<GetContactDto>(contact);
        }
    }
}
