using Report.API.Domain.Entities;
using System.Linq.Expressions;

namespace Report.API.Domain.Interfaces
{
    public interface IContactInformationRepository
    {
        Task InsertAsync(ContactInformation contactInfo);
        Task UpdateAsync(ContactInformation contactInfo);
        Task DeleteAsync(ContactInformation contactInfo);
        Task<ContactInformation> GetContactInformationById(Guid id);
        Task<ContactInformation> GetContactInformation(Expression<Func<ContactInformation, bool>> predicate);
        Task<IEnumerable<ContactInformation>> GetContactInformations();
        Task<IEnumerable<ContactInformation>> GetLocationListAsync();
        Task<IEnumerable<ContactInformation>> GetPeopleCountByLocations();
    }
}
