using CraftJackRecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftJackRecordSortShared.Data
{
    public class RecordsRepository : IRecordsRepository
    {
        protected IContext _context;

        public RecordsRepository(IContext context)
        {
            _context = context;
        }

        public void Add(Record record)
        {
            _context.Records.Add(record);
            _context.SaveChanges();
        }

        public void AddList(IList<Record> records)
        {
            foreach (Record record in records)
            {
                _context.Records.Add(record);
                _context.SaveChanges();
            }
        }

        public IList<Record> GetSortedRecords(SortMethod method)
        {
            switch (method)
            {
                case (SortMethod.Gender):
                    return _context.Records.OrderBy(record => record.Gender).ThenBy(record => record.LastName).AsQueryable().ToList();
                case (SortMethod.DateOfBirth):
                    return _context.Records.OrderBy(record => record.DateOfBirth).AsQueryable().ToList();
                case (SortMethod.LastName):
                    return _context.Records.OrderBy(record => record.LastName).AsQueryable().ToList();
                default:
                    return null;
            }
        }

        public enum SortMethod { Gender, DateOfBirth, LastName }
    }
}
