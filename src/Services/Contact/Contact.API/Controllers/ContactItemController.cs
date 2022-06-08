using Contact.Application.Commands.CreateContact;
using Contact.Application.Commands.DeleteContact;
using Contact.Application.Commands.UpdateContact;
using Contact.Application.Queries.GetContactById;
using Contact.Application.Queries.GetContacts;
using Contact.Application.Queries.GetContactWithContactInfo;
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

        [Route("api/v1/Contacts")]
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateContact([FromBody]UpdateContactCommand command)
            => Ok(await _mediator.Send(command));

        [Route("api/v1/Contacts/{id}")]
        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
            => Ok(await _mediator.Send(new DeleteContactCommand(id)));

        [Route("api/v1/Contacts/{contactId}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetContactDto>> GetContactById(Guid contactId)
            => Ok(await _mediator.Send(new GetContactByIdQuery { ContactItemId = contactId }));

        [Route("api/v1/Contacts")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetAllContactViewModel>> GetContacts()
            => Ok(await _mediator.Send(new GetContactsQuery()));

        [Route("api/v1/ContactsWithInfo/{id}")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GetContactWithContactInfosDto>> GetContactsWitInfos([FromRoute] Guid id)
            => Ok(await _mediator.Send(new GetContactWithContactInfoQuery(id)));
    }
}
