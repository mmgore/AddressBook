using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Unit>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CreateContactCommandHandler> _logger;

        public CreateContactCommandHandler(IContactItemRepository contactItemRepository,
            IContactInformationRepository contactInformationRepository,
            IUnitOfWork unitOfWork,
            ILogger<CreateContactCommandHandler> logger)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _contactInformationRepository = contactInformationRepository ?? throw new ArgumentNullException(nameof(contactInformationRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Unit> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contactItem = ContactItem.Create(request.FirstName, request.LastName, request.Firm);
            var contactInformation = ContactInformation.Create(contactItem.Id, request.PhoneNumber, request.EmailAddress, request.Location, request.Content);

            await _contactItemRepository.InsertAsync(contactItem);
            await _contactInformationRepository.InsertAsync(contactInformation);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation($"Contact with contact id - {contactItem.Id} is successfully created");

            return Unit.Value;
        }
    }
}
