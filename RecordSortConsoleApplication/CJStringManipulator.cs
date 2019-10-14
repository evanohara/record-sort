using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordSortConsoleApplication
{
    public static class CJStringManipulator
    {
        public static string GetStringOfExactLength(int exactLength, string str)
        {
            if (str.Length > exactLength)
            {
                return str.Substring(0, exactLength);
            }
            else
            {
                StringBuilder sb = new StringBuilder(str);
                for (int i = 0; i < (exactLength - str.Length); i++)
                {
                    sb.Append(' ');
                }
                return sb.ToString();
            }
        }
    }
}
