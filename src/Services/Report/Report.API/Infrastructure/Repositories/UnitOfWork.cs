using Report.API.Domain.Interfaces;
using System;

namespace Report.API.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private bool _disposed = false;

        private readonly ReportContext _reportDbContext;
        public UnitOfWork(ReportContext reportDbContext)
        {
            _reportDbContext = reportDbContext ?? throw new ArgumentNullException(nameof(reportDbContext));
        }
        public async Task SaveChangesAsync()
        {
            await _reportDbContext.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _reportDbContext.Dispose();
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
