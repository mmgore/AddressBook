using AutoMapper;
using Report.API.Application.Dtos;
using Report.API.Domain.Entities;

namespace Report.API.Application.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ContactItemDto, ContactItem>()
                .ReverseMap();
        }
    }
}
