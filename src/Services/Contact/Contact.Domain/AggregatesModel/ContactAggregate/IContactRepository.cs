using System.Linq.Expressions;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public interface IContactRepository
    {
        Task InsertAsync(Contact buyer);
        Task UpdateAsync(Contact buyer);
        Task DeleteAsync(Contact buyer);
        Task<Contact> GetBuyerById(Guid id);
        Task<Contact> GetBuyer(Expression<Func<Contact, bool>> predicate);
        Task<IEnumerable<Contact>> GetBuyers();
    }
}
