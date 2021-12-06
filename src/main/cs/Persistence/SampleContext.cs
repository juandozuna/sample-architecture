using Microsoft.EntityFrameworkCore;
using Wepsys.Polux.Sample.Persistence.models;

namespace Wepsys.Polux.Sample.Persistence
{
    /// <summary>
    ///
    /// </summary>
    public sealed class SampleContext : DbContext
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="options"></param>
        public SampleContext(DbContextOptions<SampleContext> options) : base(options)
        {
            Contacts = Set<Contact>();
        }

        /// <summary>
        ///
        /// </summary>
        public DbSet<Contact> Contacts { get;  }
    }
}