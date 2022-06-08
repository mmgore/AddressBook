using Microsoft.EntityFrameworkCore;
using Report.API.Domain.Entities;

namespace Report.API.Infrastructure
{
    public class ReportContext : DbContext
    {
        public ReportContext(DbContextOptions<ReportContext> options) : base(options)
        {
        }

        public DbSet<ContactItem> ContactItems { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
    }
}
