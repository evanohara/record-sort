using CraftJackRecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftJackRecordSortShared.Data
{
    public class Context : DbContext, IContext
    {
        public Context() : base("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CraftJackRecordsDB;Integrated Security=True;MultipleActiveResultSets=True")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<Record> Records { get; set; }
    }
}
