using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortConsoleApplication
{

    public class CJCommandValidator
    {
        private static readonly List<char> ValidCommands = new List<char>() { 'R', 'G', 'B', 'L', 'X' };

        public static bool IsValidCommand(string userInput)
        {
            if (userInput.Length != 1)
                return false;

            foreach (char validChar in ValidCommands)
            {
                if (char.ToUpper(userInput[0]) == validChar)
                    return true;
            }

            return false;
        }
    }
}
