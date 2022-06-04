using System.Linq.Expressions;

namespace Contact.Domain.AggregatesModel.ContactAggregate
{
    public interface IContactInformationRepository
    {
        Task InsertAsync(ContactInformation contactInfo);
        Task UpdateAsync(ContactInformation contactInfo);
        Task DeleteAsync(ContactInformation contactInfo);
        Task<ContactInformation> GetContactInformationById(Guid id);
        Task<ContactInformation> GetContactInformation(Expression<Func<ContactInformation, bool>> predicate);
        Task<IEnumerable<ContactInformation>> GetContactInformations();
    }
}
