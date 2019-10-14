using CraftJackRecordSortShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CraftJackRecordSortShared.Data.RecordsRepository;

namespace RecordSortConsoleApplication
{
    public static class CJPrintHelper
    {
        public static void PrintCommandPromptText()
        {
            Console.WriteLine("+===========================================================+");
            Console.WriteLine("|| Input a character for one of the corresponding options: ||");
            Console.WriteLine("|| 'R': Requests a file to add records from.               ||");
            Console.WriteLine("|| 'G': Displays all records, sorted by gender.            ||");
            Console.WriteLine("|| 'B': Displays all records, sorted by birthdate.         ||");
            Console.WriteLine("|| 'L': Displays all records, sorted by last name.         ||");
            Console.WriteLine("|| 'X': Exits the application.                             ||");
            Console.WriteLine("+===========================================================+\n");
            Console.Write("  Enter Command: ");
        }

        public static void PrintInvalidCommandPromptText()
        {
            Console.WriteLine("  Input entered was not a valid command.");
            Console.Write("  Enter Command: ");
        }

        public static void PrintFilePromptText()
        {
            Console.WriteLine("File should be located in this Application's root directory.\n");
            Console.Write("  Enter File Name: ");
        }

        public static void PrintSortedRecords(SortMethod method, IList<Record> records)
        {
            Console.WriteLine("Printing all records sorted using the " + method.ToString() + " method...\n");
            Console.WriteLine("+======================================================================================================+");
            foreach (Record record in records)
            {
                PrintSingleRecord(record);
            }
            Console.WriteLine("+======================================================================================================+");
        }

        public static void PrintSingleRecord(Record record)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|| LASTNAME=");
            sb.Append(CJStringManipulator.GetStringOfExactLength(12, record.LastName));
            sb.Append(" FIRSTNAME=");
            sb.Append(CJStringManipulator.GetStringOfExactLength(12, record.FirstName));
            sb.Append(" GENDER=");
            sb.Append(CJStringManipulator.GetStringOfExactLength(8, record.Gender));
            sb.Append(" FAVCOLOR=");
            sb.Append(CJStringManipulator.GetStringOfExactLength(8, record.FavoriteColor));
            sb.Append(" DATEOFBIRTH=");
            sb.Append(CJStringManipulator.GetStringOfExactLength(12, record.DateOfBirth.Value.ToShortDateString()));
            sb.Append(" ||");
            Console.WriteLine(sb.ToString());
        }

        public static void PrintErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void PrintSuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
