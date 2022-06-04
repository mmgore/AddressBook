using System.Linq.Expressions;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public interface IContactInformationRepository
    {
        Task InsertAsync(ContactInformation buyer);
        Task UpdateAsync(ContactInformation buyer);
        Task DeleteAsync(ContactInformation buyer);
        Task<ContactInformation> GetBuyerById(Guid id);
        Task<ContactInformation> GetBuyer(Expression<Func<ContactInformation, bool>> predicate);
        Task<IEnumerable<ContactInformation>> GetBuyers();
    }
}
