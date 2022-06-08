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
        private readonly IMapper _mapper;
        public ReportAppService(IContactItemRepository contactItemRepository,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        
    }
}
