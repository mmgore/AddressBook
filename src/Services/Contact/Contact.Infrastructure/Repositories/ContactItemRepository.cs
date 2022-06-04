using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
    public class ContactItemRepository : IContactItemRepository
    {
        private readonly IRepository<ContactItem> _repository;
        public ContactItemRepository(IRepository<ContactItem> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public Task DeleteAsync(ContactItem item)
        {
            throw new NotImplementedException();
        }

        public Task<ContactItem> GetBuyer(Expression<Func<ContactItem, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<ContactItem> GetBuyerById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContactItem>> GetBuyers()
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(ContactItem item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ContactItem item)
        {
            throw new NotImplementedException();
        }
    }
}
