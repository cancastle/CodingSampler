using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGFlooringCorp.BLL;

namespace SGFlooringCorp.UI.Utilities
{
    class UserInteractions
    {
        public static void PressKeyToContinue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }

        public static void PromptUserToContinue()
        {
            
        }

        public static string PromptForRequiredString(string message, string mode = "Add")
        {
            bool validInput = false;
            string output = "";

            while (!validInput)
            {
                Console.Write(message);
                output = Console.ReadLine();

                if (mode == "Edit" && String.IsNullOrWhiteSpace(output))
                    return output;

                if (String.IsNullOrEmpty(output))
                {
                    Console.Write("Please enter some data.");
                }
                else
                {
                    validInput = true;
                }
            }

            return output;
        }

        public static decimal PromptForDecimal(string message, string mode = "Add")
        {
            bool validInput = false;
            decimal output = 0;

            while (!validInput)
            {
                Console.Write(message);
                var input = Console.ReadLine();

                if (mode == "Edit" && String.IsNullOrWhiteSpace(input))
                    return -1;

                validInput = Decimal.TryParse(input, out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid decimal!");
                }
            }

            return output;
        }

        internal static int PromptForInt(string message)
        {
            bool validInput = false;
            int output = 0;

            while (!validInput)
            {
                Console.Write(message);
                validInput = Int32.TryParse(Console.ReadLine(), out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid number!");
                }
            }

            return output;
        }

        public static string PromptUserForConfirmation(string message)
        {
            bool validInput = false;
            string output = "";

            while (!validInput)
            {
                Console.Write(message);
                output = Console.ReadLine();


                if (String.IsNullOrEmpty(output))
                {
                    Console.WriteLine("Please make a selection.");
                }
                else
                {
                    output = output.Substring(0, 1).ToUpper();
                    if (output == "Y" || output == "N")
                        validInput = true;
                }
            }

            return output;
        }

        public static string PromptForValidState(string message)
        {
            bool validInput = false;
            string output = "";
            var taxOperations = OperationsFactory.CreateTaxOperations();

            while (!validInput)
            {
                Console.Write(message);
                output = Console.ReadLine();

                if (!taxOperations.IsValidState(output))
                {
                    Console.WriteLine("That is not a state we sell in.");
                }
                else
                {
                    validInput = true;
                }
            }

            return output;
        }

        public static DateTime PromptForDate(string message)
        {
            bool validInput = false;
            DateTime output = new DateTime();

            while (!validInput)
            {
                Console.Write(message);
                validInput = DateTime.TryParse(Console.ReadLine(), out output);

                if (!validInput)
                {
                    Console.WriteLine("That is not a valid date");
                }
            }

            return output;
        }
    }
}
