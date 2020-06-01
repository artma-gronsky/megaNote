using Domain.Entities;
using Domain.Migrations;
using System.Data.Entity;

namespace Domain
{
    public class StorageContext : DbContext
    {
        public StorageContext() : this("name=DefaultConnection")
        {
        }

        public StorageContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StorageContext, Configuration>(true));
        }

        public DbSet<Note> Notes { get; set; }
    }
}
