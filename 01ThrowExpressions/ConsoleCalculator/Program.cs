using System;
using static System.Console;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain currentAppDomain = AppDomain.CurrentDomain;
            currentAppDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleException);
            //Basically saying, "Sorry there was a problem and we need to close the app"
            //the unhandled exception was a System.FormatException

            WriteLine("Enter first number");
            int number1 = int.Parse(ReadLine());

            WriteLine("Enter second number");
            int number2 = int.Parse(ReadLine());

            WriteLine("Enter operation");
            string operation = ReadLine().ToUpperInvariant();


            var calculator = new Calculator();

            try
            {
                int result = calculator.Calculate(number1, number2, null);
                DisplayResult(result);
            }
            catch (ArgumentNullException ex) when (ex.ParamName == "operation") //only execute this catch block
            //if it was operation parameter that was null. 
            {
                WriteLine($"Operationn was not provided. {ex}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                WriteLine($"Operation is not supported. {ex}");
            }
            catch (Exception ex)
            {
                WriteLine($"Sorry, something went wrong. {ex}");
            }
            finally
            {
                //can help track the end of the console error messages
                WriteLine("....finally...");
            }
            


            
            WriteLine("\nPress enter to exit.");
            ReadLine();
        }

        private static void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            //Basically saying, "Sorry there was a problem and we need to close the app"
            WriteLine($"Sorry, there was a problem and we need to close. Details: {e.ExceptionObject}");
        }

        private static void DisplayResult(int result)
        {
            WriteLine($"Result is: {result}");
        }
    }
}
