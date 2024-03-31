using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GridNavigation.Classes
{
    public delegate void InvalidMarker();

    //public delegate void MyNewDelegate();

    public class Grid
    {
        //This event is triggerred when marker position is changed
        public event EventHandler onMarkerMoved;

        //Total number of grid rows
        private int _rows;

        //Total number of grid columns
        private int _columns;

        //List for Marker history
        private List<Marker> markerHistory;

        //Current Marker position
        public Marker currentPosition;

        public Grid(int rows, int columns)
        {
            _rows = rows; _columns = columns;

            markerHistory = new List<Marker>();

            SetMarker(1, 1);
        }
        
        public List<Marker> GetMarkerHistory()
        {
            return markerHistory;
        }

        //Sets the marker position
        public void SetMarker(int row, int column)
        {
            currentPosition.row = row;
            currentPosition.column = column;

            markerHistory.Add(new Marker { row = row, column = column });
        }

        public bool isValidGridBounds()
        {
            //return true if row and columns are greater than 0
            return _rows > 0 && _columns > 0;
        }

        public void Up()
        {
            if(currentPosition.row > 1)
            {
                currentPosition.row--;

                AddCurrentMarkerToHistory();

                //notify marker move
                onMarkerMoved?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Down()
        {
            if (currentPosition.row < _rows)
            {
                currentPosition.row++;

                AddCurrentMarkerToHistory();

                //notify marker move
                onMarkerMoved?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Left()
        {
            if (currentPosition.column > 1)
            {
                currentPosition.column--;

                AddCurrentMarkerToHistory();

                //notify marker move
                onMarkerMoved?.Invoke(this, EventArgs.Empty);
            }
        }

        public void Right()
        {
            if (currentPosition.column < _columns)
            {
                currentPosition.column++;

                AddCurrentMarkerToHistory();

                //notify marker move
                onMarkerMoved?.Invoke(this, EventArgs.Empty);
            }
        }

        public void AddCurrentMarkerToHistory()
        {
            markerHistory.Add(new Marker() { row = currentPosition.row, column = currentPosition.column });
        }
    }
}
