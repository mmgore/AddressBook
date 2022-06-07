using MediatR;

namespace Contact.Application.Commands.DeleteContactInfo
{
    public class DeleteContactInfoCommand : IRequest
    {
        public Guid Id { get; private set; }
        public DeleteContactInfoCommand(Guid id)
        {
            Id = id;
        }
    }
}
