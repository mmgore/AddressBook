using AutoMapper;
using Contact.Application.Commands.UpdateContact;
using Contact.Application.Queries;
using Contact.Domain.AggregatesModel.ContactAggregate;

namespace Contact.Application.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<UpdateContactCommand, ContactItem>()
                .ReverseMap();
            CreateMap<GetContactDto, ContactItem>()
                .ReverseMap();
        }
    }
}
