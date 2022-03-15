using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Common;
using Model.EfDbConfiguration;
using Model.Model;

namespace Model
{
    [DbConfigurationType(typeof(SqlContextDbConfiguration))]
    public class SQLContext : DbContext
    {
#if DEBUG

        // This is a workaround for EF issue that occurs when performing integration testing
        // using some of the unit testing runners. The issue is described here:
        // https://entityframework.codeplex.com/workitem/1590
        // ReSharper disable once UnusedMember.Local
        private static readonly MicrosoftSqlProviderServices _var = MicrosoftSqlProviderServices.Instance;

#endif
        private static readonly string DefaultConnectionStringName = "DB_" + ConfigurationManager.AppSettings["ENV"];
        private static string _connectionStringName;

        static SQLContext()
        {
            SetInitializer(DefaultConnectionStringName);
        }

        public SQLContext()
            : base(_connectionStringName)
        {
            // Increase command timeout in order to allow longer running queries.
            Database.CommandTimeout = Config.CommandTimeoutSec;
            // this.Database.Log += s => Debug.WriteLine(s);
        }

        public IDbSet<Institution> Institutions { get; set; }


        internal static void SetInitializer(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
            Database.SetInitializer<SQLContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}