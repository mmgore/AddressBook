﻿using Microsoft.EntityFrameworkCore;
using Report.API.Domain.Entities;
using Report.API.Domain.Interfaces;
using System.Linq.Expressions;

namespace Report.API.Infrastructure.Repositories
{
    public class ContactInformationRepository : IContactInformationRepository
    {
        private readonly IRepository<ContactInformation> _repository;
        public ContactInformationRepository(IRepository<ContactInformation> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task DeleteAsync(ContactInformation contactInfo)
        {
            await _repository.DeleteAsync(contactInfo);
        }

        public async Task<ContactInformation> GetContactInformation(Expression<Func<ContactInformation, bool>> predicate)
            => await _repository.GetAsync(predicate);

        public async Task<ContactInformation> GetContactInformationById(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<ContactInformation>> GetContactInformations()
            => await _repository.GetAllAsync();

        public async Task InsertAsync(ContactInformation contactInfo)
        {
            await _repository.InsertAsync(contactInfo);
        }

        public async Task UpdateAsync(ContactInformation contactInfo)
        {
            await _repository.UpdateAsync(contactInfo);
        }

        public async Task<IEnumerable<ContactInformation>> GetLocationListAsync()
        {
            return await _repository.Queryable()
                                        .GroupBy(x => x.Location)
                                        .Select(p => new ContactInformation { Location = p.Key, Count = p.Count() })
                                        .OrderByDescending(o => o.Count)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<ContactInformation>> GetPeopleCountByLocations()
        {
            var data = await _repository.Queryable()
                                        .GroupBy(x => new { x.Location, x.ContactItemId})
                                        .Select(p => new ContactInformation { Location = p.Key.Location, ContactItemId = p.Key.ContactItemId, Count = p.Count() })
                                        .OrderByDescending(o => o.Count)
                                        .ToListAsync();

            return data.GroupBy(x => x.Location)
                       .Select(p => new ContactInformation { Location = p.Key, Count = p.Count() })
                       .OrderByDescending(o => o.Count)
                       .ToList();

        }

        public async Task<IEnumerable<ContactInformation>> GetPhoneNumberCountByLocations()
        {
            var data = await _repository.Queryable()
                                       .GroupBy(x => new { x.Location, x.PhoneNumber })
                                       .Select(p => new ContactInformation { Location = p.Key.Location, PhoneNumber = p.Key.PhoneNumber, Count = p.Count() })
                                       .OrderByDescending(o => o.Count)
                                       .ToListAsync();

            return data.GroupBy(x => x.Location)
                       .Select(p => new ContactInformation { Location = p.Key, Count = p.Count() })
                       .OrderByDescending(o => o.Count)
                       .ToList();
        }
    }
}
