using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public interface IBoard
    {
        /// <summary>
        /// Attempts to put a new chip on the board and returns the position of the new placed chip
        /// if fails - [-1,-1] returned
        /// </summary>
        Tuple<int, int> PlacePlayerChip(ICell cell, int column);

        IEnumerable<ICell> GetCellInRange(IEnumerable<Tuple<int, int>> range);

        IEnumerable<int> GetAvailableColumns();

        int Rows { get; }

        int Columns { get; }

        void Print();
    }

  
    public class InvalidMoveException : Exception
    {
        public InvalidMoveException(string msg)
            :base(msg)
        {

        }
    }
}
