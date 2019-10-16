using RecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortShared.Data
{
    public interface IRecordsRepository
    {
        void Add(Record record);

        void AddList(IList<Record> records);

        IList<Record> GetSortedRecords(RecordsRepository.SortMethod method);
    }
}
