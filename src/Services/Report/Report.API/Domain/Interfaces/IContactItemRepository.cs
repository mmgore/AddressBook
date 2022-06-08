using Report.API.Domain.Entities;
using System.Linq.Expressions;

namespace Report.API.Domain.Interfaces
{
    public interface IContactItemRepository
    {
        Task InsertAsync(ContactItem item);
        Task UpdateAsync(ContactItem item);
        Task DeleteAsync(ContactItem item);
        Task<ContactItem> GetContactItemById(Guid id);
        Task<ContactItem> GetContactItem(Expression<Func<ContactItem, bool>> predicate);
        Task<IEnumerable<ContactItem>> GetContactItems();
        Task<ContactItem> GetContactItemsWithInfos(Guid id);
    }
}
