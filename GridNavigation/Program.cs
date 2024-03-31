// See https://aka.ms/new-console-template for more information
using GridNavigation.Classes;
using GridNavigation.Helper;

/*
         Separation of concern: Grid and Navigation classes are independent of each other. 
         - Grid should have only functionality related to Grid and should not be worried about navigation
         - Navigation class is only concerned with navigation, and should be unaware of consumer of navigation events.
         - So Grid class should not be tightly coupled to Navigation and vice versa
*/


Helper.PrintWelcomeMessage();

/*
        Create a Grid object and let user decide the grid size (row, columns).
        Entering 0 will abort (giving user a chance if he decides not to play after the program is started)
*/

InputReader inputReader = new InputReader();
int rowBound = 0, columnBound = 0;
    
rowBound = inputReader.ReadNumberOfRows();

if(rowBound > 0)
{
    columnBound = inputReader.ReadNumberOfColumns();
}

if (rowBound == 0 || columnBound == 0)
{
    Console.WriteLine("Row or Column bound must be greater than zero. Exiting application.");
    Environment.Exit(0);
}


//Create Grid Object
Grid grid = new Grid(rowBound, columnBound);

//marker movements event handler. Triggerred when marker position is changed within the grid
grid.onMarkerMoved += HandleMarkerMovement;


/*
        Create Navigation object and subscribe to navigation events. 
        Navigation events are triggerred when left, right, up, down arrow keys are pressed
        Entering Esc will abort the program
*/
Navigation navigation = new Navigation();
navigation.OnNavigationOccurred += HandleNavigationEvent;


//Display current position
Helper.printRowColumnHeader();
diplayMarkerPosition(grid.currentPosition);


/*
        Enter the loop. capture navigation events
*/

//handle arrow keys (and Esc to exit)
navigation.BeginNavigation();


//Navigation event handler
 void HandleNavigationEvent(object? sender, ConsoleKey key)
{
    switch (key)
    {
        case ConsoleKey.UpArrow:
            grid.Up();
            break;

        case ConsoleKey.DownArrow:
            grid.Down();
            break;

        case ConsoleKey.LeftArrow:
            grid.Left();
            break;

        case ConsoleKey.RightArrow:
            grid.Right();
            break;

        case ConsoleKey.Escape:
            //When Esc is pressed, display the navigation history, and exit the application
            DisplayMarkerNavigationHistory();

            //Unsubscribe
            navigation.OnNavigationOccurred -= HandleNavigationEvent;
            grid.onMarkerMoved -= HandleMarkerMovement;

            Console.ReadLine();
            Environment.Exit(0);
            break;
    }
}


//Display the marker navigation history before existing program (Pressing Esc key ends the navigation loop)
void DisplayMarkerNavigationHistory()
{
    Console.WriteLine("\n\n*****************************************************");
    Console.WriteLine("             Navigation History                 ");
    Console.WriteLine("*****************************************************");
    Helper.printRowColumnHeader();

    foreach (Marker marker in grid.GetMarkerHistory())
    {
        diplayMarkerPosition(marker);
    }
}

//Event handler for marker movement (triggerred by grid whenever marker position is changed)
void HandleMarkerMovement(object? sender, EventArgs e)
{
    diplayMarkerPosition(grid.currentPosition);
}

//Displays the marker position
void diplayMarkerPosition(Marker marker)
{
    Console.WriteLine($"Pos: {marker.row} : {marker.column}");
}


