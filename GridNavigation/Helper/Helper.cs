using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridNavigation.Helper
{
    public static class Helper
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\n\n-------------------------------------------------------------");
            Console.WriteLine("              ! Welcome to Grid Navigation !                   ");
            Console.WriteLine("-------------------------------------------------------------");

            Console.WriteLine("\n\nInstructions: - Maximum number of rows/columns: 10");
            Console.WriteLine("              - Use arrow keys to navigate thru Grid cells. ");
            Console.WriteLine("              - Entering 0 for row/column size will abort the program");
            Console.WriteLine("              - Press Esc anytime to end the navigation.");

            Console.Write("\n\n\n");
        }


        //Display the header for marker position
        public static void printRowColumnHeader()
        {
            Console.WriteLine("---------------------");
            Console.WriteLine("    row : Column");
            Console.WriteLine("---------------------");
        }
    }
}
