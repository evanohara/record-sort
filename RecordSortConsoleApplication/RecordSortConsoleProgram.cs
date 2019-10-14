using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CraftJackRecordSortShared.Models;
using CraftJackRecordSortShared.Data;

namespace RecordSortConsoleApplication
{
    // The main loop has the following steps
    // Get a command from the user
    public static class RecordSortConsoleProgram
    {
        static RecordsRepository _recordsRepository;

        static void Main(string[] args)
        {
            using (Context context = new Context())
            {
                _recordsRepository = new RecordsRepository(context);

                while (true)
                {
                    //  Get a Command to Execute
                    string userInput = PromptUser(PromptType.Command);
                    while (!CJCommandValidator.IsValidCommand(userInput))
                    {
                        userInput = PromptUser(PromptType.InvalidCommand);
                    }
                    char command = char.ToUpper(userInput[0]);

                    //  Execute that command
                    switch (command)
                    {
                        //  Add Records from a file to the repository
                        case 'R':
                            userInput = PromptUser(PromptType.File);
                            string path = AppDomain.CurrentDomain.BaseDirectory + userInput;

                            IList<Record> recordsToAddToDB = null;

                            try
                            {
                                using (StreamReader file = new StreamReader(path))
                                {
                                    recordsToAddToDB = CJFileParser.ParseFile(file);
                                }
                            }
                            catch (IOException e)
                            {
                                CJPrintHelper.PrintErrorMessage("Could not load the file.");
                            }

                            if (recordsToAddToDB == null)
                            {
                                CJPrintHelper.PrintErrorMessage("There are no valid records to be added.");
                            }
                            else
                            {
                                _recordsRepository.AddList(recordsToAddToDB);
                                CJPrintHelper.PrintSuccessMessage("Records created successfully!");
                            }
                            break;

                        // Print Records ordered by gender
                        case 'G':
                            IList<Record> printMe = _recordsRepository.GetSortedRecords(RecordsRepository.SortMethod.Gender);
                            CJPrintHelper.PrintSortedRecords(RecordsRepository.SortMethod.Gender, printMe);
                            break;
                        // Print Records ordered by DOB
                        case 'B':
                            printMe = _recordsRepository.GetSortedRecords(RecordsRepository.SortMethod.DateOfBirth);
                            CJPrintHelper.PrintSortedRecords(RecordsRepository.SortMethod.DateOfBirth, printMe);
                            break;
                        // Print Records ordered by last name
                        case 'L':
                            printMe = _recordsRepository.GetSortedRecords(RecordsRepository.SortMethod.LastName);
                            CJPrintHelper.PrintSortedRecords(RecordsRepository.SortMethod.LastName, printMe);
                            break;
                        // Escapes the program
                        case 'X':
                            Console.WriteLine("Thanks for stopping by....");
                            return;
                        default:
                            break;
                    }
                }
            }
        }



        //  Reusable Prompter for any occasion.
        public static string PromptUser(PromptType promptType)
        {
            switch (promptType)
            {
                case PromptType.Command:
                    CJPrintHelper.PrintCommandPromptText();
                    break;
                case PromptType.InvalidCommand:
                    CJPrintHelper.PrintInvalidCommandPromptText();
                    break;
                case PromptType.File:
                    CJPrintHelper.PrintFilePromptText();
                    break;
            }

            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput;
        }
    }
}

public enum PromptType { Command, InvalidCommand, File }

