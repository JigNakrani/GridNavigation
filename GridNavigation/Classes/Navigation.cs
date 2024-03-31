using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridNavigation.Classes
{
    public class Navigation
    {
        //this event is triggerred whenever allowed movement happens (arrow keys, or Esc key)
        public event EventHandler<ConsoleKey> OnNavigationOccurred;
        
        public Navigation()
        {
        }
        internal void BeginNavigation()
        {
            while (true)
            {
                //Read key input
                ConsoleKeyInfo KeyInfo = Console.ReadKey(true);

                //trigger event for valid movement
                if(KeyInfo.Key == ConsoleKey.Escape
                    || KeyInfo.Key == ConsoleKey.UpArrow
                    || KeyInfo.Key == ConsoleKey.DownArrow
                    || KeyInfo.Key == ConsoleKey.LeftArrow
                    || KeyInfo.Key == ConsoleKey.RightArrow
                ) {
                    OnNavigationOccurred?.Invoke(this, KeyInfo.Key);
                }
            }

            
        }
    }
}
