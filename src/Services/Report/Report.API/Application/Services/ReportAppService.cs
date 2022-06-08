using AutoMapper;
using Report.API.Application.Dtos;
using Report.API.Application.Interfaces;
using Report.API.Domain.Entities;
using Report.API.Domain.Interfaces;

namespace Report.API.Application.Services
{
    public class ReportAppService : IReportAppService
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IContactInformationRepository _contactInformationRepository;
        private readonly IMapper _mapper;
        public ReportAppService(IContactItemRepository contactItemRepository,
            IContactInformationRepository contactInformationRepository,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _contactInformationRepository = contactInformationRepository ?? throw new ArgumentNullException(nameof(contactInformationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<LocationListDto>> GetLocationListAsync()
        {
            var locations = await _contactInformationRepository.GetLocationListAsync();
            List<LocationListDto> locationListDto = new List<LocationListDto>();
            foreach (var item in locations)
            {
                LocationListDto locationDto = new LocationListDto();
                locationDto.Location = item.Location;
                locationDto.Count = item.Count.ToString();
                locationListDto.Add(locationDto);
            }

            return locationListDto;
        }
    }
}
