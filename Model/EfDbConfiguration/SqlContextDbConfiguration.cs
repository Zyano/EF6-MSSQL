using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Model.EfDbConfiguration
{
    public class SqlContextDbConfiguration : DbConfiguration
    {
        public SqlContextDbConfiguration()
        {
            SetProviderFactory(MicrosoftSqlProviderServices.ProviderInvariantName, Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            SetProviderServices(MicrosoftSqlProviderServices.ProviderInvariantName, MicrosoftSqlProviderServices.Instance);
        }
    }
}
