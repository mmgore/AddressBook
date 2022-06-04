using System.Linq.Expressions;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public interface IContactItemRepository
    {
        Task InsertAsync(ContactItem item);
        Task UpdateAsync(ContactItem item);
        Task DeleteAsync(ContactItem item);
        Task<ContactItem> GetBuyerById(Guid id);
        Task<ContactItem> GetBuyer(Expression<Func<ContactItem, bool>> predicate);
        Task<IEnumerable<ContactItem>> GetBuyers();
    }
}
