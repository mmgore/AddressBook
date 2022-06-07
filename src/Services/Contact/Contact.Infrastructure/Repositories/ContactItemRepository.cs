using Contact.Domain.AggregatesModel.ContactAggregate;
using Contact.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Contact.Infrastructure.Repositories
{
    public class ContactItemRepository : IContactItemRepository
    {
        private readonly IRepository<ContactItem> _repository;
        public ContactItemRepository(IRepository<ContactItem> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task DeleteAsync(ContactItem item)
        {
             await _repository.DeleteAsync(item);
        }

        public async Task<ContactItem> GetContactItem(Expression<Func<ContactItem, bool>> predicate)
            => await _repository.GetAsync(predicate);

        public async Task<ContactItem> GetContactItemById(Guid id)
            => await _repository.GetAsync(id);

        public async Task<IEnumerable<ContactItem>> GetContactItems()
            =>  await _repository.GetAllAsync();

        public async Task<ContactItem> GetContactItemsWithInfos(Guid id)
            => await _repository.Queryable(x => x.Id == id).Include(c => c.ContactInformations).FirstOrDefaultAsync();
        
        public async Task InsertAsync(ContactItem item)
        {
            await _repository.InsertAsync(item);
        }

        public async Task UpdateAsync(ContactItem item)
        {
            await _repository.UpdateAsync(item);
        }
    }
}
