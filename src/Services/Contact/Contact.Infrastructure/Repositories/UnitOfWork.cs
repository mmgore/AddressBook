using Contact.Domain.SeedWork;

namespace Contact.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;

        private readonly ContactContext _contactDbContext;
        public UnitOfWork(ContactContext contactDbContext)
        {
            _contactDbContext = contactDbContext ?? throw new ArgumentNullException(nameof(contactDbContext));
        }
        public async Task SaveChangesAsync()
        {
            await _contactDbContext.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _contactDbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
