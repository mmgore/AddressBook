using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Application.Dtos;
using Report.API.Application.Interfaces;
using Report.API.Domain.Interfaces;
using System.Net;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportAppService _reportAppService;
        public ReportController(IReportAppService reportAppService)
        {
            _reportAppService = reportAppService ?? throw new ArgumentNullException(nameof(reportAppService));
        }

        
    }
}
