﻿using System;

namespace ConsoleCalculator
{
    public class Calculator
    {
        public int Calculate(int number1, int number2, string operation)
        {
            if (operation == "/")
            {
                return Divide(number1, number2);
            }
            else
            {
                //if you type in 0, do this exception
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

