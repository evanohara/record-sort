using RecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortShared.Data
{
    public interface IContext
    {
        DbSet<Record> Records { get; set; }
        int SaveChanges();
    }
}
