using MediatR;

namespace Contact.Application.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest
    {
        public Guid Id { get; private set; }
        public DeleteContactCommand(Guid id)
        {
            Id = id;
        }
    }
}
