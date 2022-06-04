using System.Linq.Expressions;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public interface IContactInformationRepository
    {
        Task InsertAsync(ContactInformation contactInfo);
        Task UpdateAsync(ContactInformation contactInfo);
        Task DeleteAsync(ContactInformation contactInfo);
        Task<ContactInformation> GetBuyerById(Guid id);
        Task<ContactInformation> GetBuyer(Expression<Func<ContactInformation, bool>> predicate);
        Task<IEnumerable<ContactInformation>> GetBuyers();
    }
}
