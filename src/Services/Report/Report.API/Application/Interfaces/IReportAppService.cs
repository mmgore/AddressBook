using Report.API.Application.Dtos;

namespace Report.API.Application.Interfaces
{
    public interface IReportAppService
    {
        Task<IEnumerable<LocationListDto>> GetLocationListAsync();
        Task<IEnumerable<PeopleCountByLocationDto>> GetPeopleCountByLocations();
        Task<IEnumerable<PhoneNumberCountByLocationDto>> GetPhoneNumberCountByLocations();
    }
}
