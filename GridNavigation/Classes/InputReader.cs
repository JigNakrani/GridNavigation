using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridNavigation.Classes
{
    internal class InputReader
    {
        public InputReader() {  }

        public int ReadNumberOfRows()
        {
            return ReadIntegerInput("rows");
        }
        public int ReadNumberOfColumns()
        {
            return ReadIntegerInput("columns");
        }

        //Reads the valid integer input (positive integer)
        private int ReadIntegerInput(string dimension)
        {
            string? size = "";
            int dimensionSize = 0;
            bool isValidNumber = false;

            //Read number of rows
            Console.Write($"Please enter number of {dimension} (zero to abort): ");

            while (true)
            {
                //Accept valid number input. Press Esc to exit and end the program
                if (isValidNumber == false)
                {
                    size = Console.ReadLine();
                }
                else
                {
                    return dimensionSize;
                }

                //check for valid input
                if (string.IsNullOrEmpty(size))
                {
                    Console.Write("Plesae enter valid number: ");
                    continue;
                }

                //check for valid input
                if (int.TryParse(size, out dimensionSize) == false)
                {
                    Console.Write("Plesae enter valid number: ");
                    continue;
                }

                //check if number is greater than zero
                if (int.TryParse(size, out dimensionSize))
                {
                    if (dimensionSize < 0)
                    {
                        Console.Write("Plesae enter a number greater than zero: ");
                        continue;
                    }
                }

                isValidNumber = true;
            }
        }
    }

    
}
