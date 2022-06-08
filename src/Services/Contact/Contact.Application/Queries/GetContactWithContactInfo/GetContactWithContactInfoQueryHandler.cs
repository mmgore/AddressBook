﻿using AutoMapper;
using Contact.Domain.AggregatesModel.ContactAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Application.Queries.GetContactWithContactInfo
{
    public class GetContactWithContactInfoQueryHandler : IRequestHandler<GetContactWithContactInfoQuery, GetContactWithContactInfosDto>
    {
        private readonly IContactItemRepository _contactItemRepository;
        private readonly IMapper _mapper;
        public GetContactWithContactInfoQueryHandler(IContactItemRepository contactItemRepository,
            IMapper mapper)
        {
            _contactItemRepository = contactItemRepository ?? throw new ArgumentNullException(nameof(contactItemRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<GetContactWithContactInfosDto> Handle(GetContactWithContactInfoQuery request, CancellationToken cancellationToken)
        {
            var contactWithInfos = await _contactItemRepository.GetContactItemsWithInfos(request.Id);

            var contactWithInfosDto = _mapper.Map<GetContactWithContactInfosDto>(contactWithInfos);

            foreach (var contactInfo in contactWithInfos.ContactInformations)
            {
                var contactInfoDto = _mapper.Map<ContactInfoDto>(contactInfo);
                contactWithInfosDto.ContactInfos.Add(contactInfoDto);
            }

            return contactWithInfosDto;

        }
    }
}
