using System.Data.Entity;
using System.Data.Entity.Infrastructure;


namespace Domain
{
    public class StorageConfiguration : DbConfiguration
    {
        public StorageConfiguration()
        {
            SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
            SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
        }
    }
}
