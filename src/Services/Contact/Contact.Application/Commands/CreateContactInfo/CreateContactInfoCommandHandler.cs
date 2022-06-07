using Contact.Application.Exceptions;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.Commands.CreateContactInfo
{
    public class CreateContactInfoCommandHandler : IRequestHandler<CreateContactInfoCommand, Unit>
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateContactInfoCommandHandler> _logger;
        public CreateContactInfoCommandHandler(IContactInformationRepository contactInformationRepository,
            IContactItemRepository contactItemRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateContactInfoCommandHandler> logger)
        {
            _contactInformationRepository = contactInformationRepository ?? throw new ArgumentNullException(nameof(contactInformationRepository));
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Unit> Handle(CreateContactInfoCommand request, CancellationToken cancellationToken)
        {
            
            var contact = await _contactItemRepository.GetContactItemById(request.ContactItemId);
            if (contact == null)
            {
                throw new NotFoundException(nameof(contact), request.ContactItemId);
            }
            var contactInfo = ContactInformation.Create(request.ContactItemId, request.PhoneNumber, request.EmailAddress, request.Location, request.Content);

            await _contactInformationRepository.InsertAsync(contactInfo);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation($"Contact with contact id - {contactInfo.Id} is successfully created");

            return Unit.Value;
        }
    }
}
