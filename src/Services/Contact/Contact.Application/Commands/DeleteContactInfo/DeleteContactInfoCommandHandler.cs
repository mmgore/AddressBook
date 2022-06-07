using Contact.Application.Exceptions;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Contact.Application.Commands.DeleteContactInfo
{
    public class DeleteContactInfoCommandHandler : IRequestHandler<DeleteContactInfoCommand, Unit>
    {
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DeleteContactInfoCommandHandler> _logger;
        public DeleteContactInfoCommandHandler(IContactInformationRepository contactInformationRepository,
            IUnitOfWork unitOfWork,
            ILogger<DeleteContactInfoCommandHandler> logger)
        {
            _contactInformationRepository = contactInformationRepository ?? throw new ArgumentNullException(nameof(contactInformationRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Unit> Handle(DeleteContactInfoCommand request, CancellationToken cancellationToken)
        {
            var contactInfo = await _contactInformationRepository.GetContactInformationById(request.Id);
            if (contactInfo == null)
            {
                throw new NotFoundException(nameof(contactInfo), request.Id);
            }

            await _contactInformationRepository.DeleteAsync(contactInfo);
            await _unitOfWork.SaveChangesAsync();
            _logger.LogInformation($"Contact with contact id - {contactInfo.Id} is successfully deleted");

            return Unit.Value;
        }
    }
}
