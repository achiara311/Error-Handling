using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public int Calculate(int number1, int number2, string operation)
        {
            throw new ArgumentNullException(nameof(number1));

            string nonNullOperation = 
                operation ?? throw new ArgumentNullException(nameof(operation));
            //if operation is NOTNULL(??), then capture nonnull operation variable ?? (else) throw this specific 
            //ArgumentNullException

            //if (operation is null)
            //{
            //    throw new ArgumentNullException(nameof(operation));
            //}

            if (nonNullOperation == "/")
            {
                try
                {
                    return Divide(number1, number2);
                }
                catch(DivideByZeroException ex)
                {
                    //throw; 
                    //dont do throw ex;

                    throw new ArgumentOutOfRangeException("An error occurred during calculation.",ex);
                    //ex is the InnerException, basically the original exception that occurred earlier
                    //itll show that the original exception that we wrapped was the DivideByZeroException
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(operation),
                    "The mathematical operator is not supported.");

                //Console.WriteLine("Unknown operation.");
                //return 0;
            }
        }
        
        private int Divide(int number, int divisor)
        {
            return number / divisor;
        }
    }
}

