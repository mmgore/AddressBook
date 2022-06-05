using AutoMapper;
using Contact.Application.Exceptions;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Unit>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdateContactCommandHandler> _logger;
        private readonly IMapper _mapper;
        public UpdateContactCommandHandler(IContactItemRepository contactItemRepository,
            IUnitOfWork unitOfWork,
            ILogger<UpdateContactCommandHandler> logger,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactItemRepository.GetContactItemById(request.Id);

            if (contact == null)
            {
                throw new NotFoundException(nameof(ContactItem), request.Id);
            }

            _mapper.Map(request, contact, typeof(UpdateContactCommand), typeof(ContactItem));

            await _contactItemRepository.UpdateAsync(contact);
            await _unitOfWork.SaveChangesAsync();

            _logger.LogInformation($"Contact with contact id - {contact.Id} is successfully updated");

            return Unit.Value;
        }
    }
}
