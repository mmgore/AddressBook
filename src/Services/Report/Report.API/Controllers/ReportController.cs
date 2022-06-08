using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Application.Dtos;
using Report.API.Application.Interfaces;
using Report.API.Domain.Interfaces;
using System.Net;

namespace Report.API.Controllers
{
    
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportAppService _reportAppService;
        public ReportController(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService ?? throw new ArgumentNullException(nameof(reportAppService));
        }

        [Route("api/v1/LocationReport")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<LocationListDto>> GetLocationList()
            => Ok(await _reportAppService.GetLocationListAsync());

        [Route("api/v1/PeopleCountByLocation")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PeopleCountByLocationDto>> GetPeopleCountByLocation()
            => Ok(await _reportAppService.GetPeopleCountByLocations());

        [Route("api/v1/PhoneNumberCountByLocation")]
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<PeopleCountByLocationDto>> GetPhoneNumberCountByLocation()
           => Ok(await _reportAppService.GetPhoneNumberCountByLocations());
    }
}
