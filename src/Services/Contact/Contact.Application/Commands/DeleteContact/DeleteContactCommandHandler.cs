using AutoMapper;
using Contact.Application.Exceptions;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteContactCommandHandler> _logger;
        private readonly IMapper _mapper;
        public DeleteContactCommandHandler(IContactItemRepository contactItemRepository,
            IUnitOfWork unitOfWork,
            ILogger<DeleteContactCommandHandler> logger,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactItemRepository.GetContactItemById(request.Id);
            
            if (contact == null)
            {
                throw new NotFoundException(nameof(contact), request.Id);
            }

            await _contactItemRepository.DeleteAsync(contact);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
