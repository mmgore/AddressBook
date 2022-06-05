using Contact.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact.Infrastructure.Repositories
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;

        private readonly ContactContext _contactDbContext;
        public UnitOfWork(ContactContext contactDbContext)
        {
            _contactDbContext = contactDbContext ?? throw new ArgumentNullException(nameof(contactDbContext));
        }
        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
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
