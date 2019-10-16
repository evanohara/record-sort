using RecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortConsoleApplication
{
    public static class CJFileParser
    {
        private static readonly List<char> ExpectedDelimiters = new List<char>() { '|', ' ', ',' };

        private static char _delimiter;

        public static IList<Record> ParseFile(StreamReader file)
        {
            IList<Record> records = new List<Record>();

            string line = file.ReadLine();

            if (!DetectDelimiter(line))
            {
                return null;

            }
            else
            {
                while (line != null)
                {
                    if (GetValidData(line, out Record record))
                    {
                        records.Add(record);
                    }
                    else
                    {
                        return null;
                    }
                    line = file.ReadLine();
                }
                return records;
            }
        }

        private static bool DetectDelimiter(string line)
        {
            string[] splittedData;

            foreach (char expDelim in ExpectedDelimiters)
            {
                splittedData = line.Split(expDelim);
                if (splittedData.Length == 5)
                {
                    _delimiter = expDelim;
                    return true;
                }
            }
            _delimiter = 'x';
            return false;
        }

        // After Messing With Tests and Test Coverage, my brain automatically knew 
        // That this should be a parse method belonging to the Record Class.  Crazy.
        private static bool GetValidData(string line, out Record record)
        {
            string[] splittedData = line.Split(_delimiter);
            record = null;

            if (splittedData.Length == 5)
            {
                if (DateTime.TryParse(splittedData[4], out DateTime dateOfBirth))
                {
                    record = new Record()
                    {
                        LastName = splittedData[0],
                        FirstName = splittedData[1],
                        Gender = splittedData[2],
                        FavoriteColor = splittedData[3],
                        DateOfBirth = dateOfBirth
                    };
                    return true;
                }
            }
            return false;
        }
    }
}
