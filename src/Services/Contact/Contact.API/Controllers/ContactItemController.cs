using Contact.Application.Commands.CreateContact;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [Route("api/v1/Contacts")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateContact([FromBody]CreateContactCommand command)
            => Ok(await _mediator.Send(command));

    }
}
