using Contact.Application.Commands.CreateContactInfo;
using Contact.Application.Commands.DeleteContactInfo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ContactInformationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [Route("api/v1/ContactInformations")]
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateContactInformation([FromBody] CreateContactInfoCommand command)
            => Ok(await _mediator.Send(command));

        [Route("api/v1/ContactInformations/{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteContactInformation([FromRoute] Guid id)
            => Ok(await _mediator.Send(new DeleteContactInfoCommand(id)));
    }
}
