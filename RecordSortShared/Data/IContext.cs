using CraftJackRecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftJackRecordSortShared.Data
{
    public interface IContext
    {
        DbSet<Record> Records { get; set; }
        int SaveChanges();
    }
}
