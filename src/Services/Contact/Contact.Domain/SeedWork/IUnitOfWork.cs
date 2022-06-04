namespace Contact.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
