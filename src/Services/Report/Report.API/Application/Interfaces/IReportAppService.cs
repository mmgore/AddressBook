using Report.API.Application.Dtos;
using Report.API.Domain.Entities;
using System.Collections.Generic;

namespace Report.API.Application.Interfaces
{
    public interface IReportAppService
    {
        Task<IEnumerable<LocationListDto>> GetLocationListAsync();
    }
}
