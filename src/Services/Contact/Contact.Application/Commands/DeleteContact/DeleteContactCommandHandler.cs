using Contact.Application.Exceptions;
using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using MediatR;

namespace Contact.Application.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, Unit>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteContactCommandHandler(IContactItemRepository contactItemRepository,
            IUnitOfWork unitOfWork)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
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
