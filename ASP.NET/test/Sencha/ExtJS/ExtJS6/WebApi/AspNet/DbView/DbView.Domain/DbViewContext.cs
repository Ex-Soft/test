using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DbView.Domain
{
    class DbViewContext : DbContext
    {
        public DbViewContext(DbConnection connection, DbCompiledModel model, bool contextOwnsConnection) : base(connection, model, contextOwnsConnection)        {
            Database.SetInitializer<DbViewContext>(null);
        }
    }
}
