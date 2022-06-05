using MediatR;

namespace Contact.Application.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
