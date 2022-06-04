﻿using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using System.Linq.Expressions;

namespace Contact.Infrastructure.Repositories
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
    }
}
