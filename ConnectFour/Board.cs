using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Board : IBoard
    {
        private ICell[ , ] board;
        private readonly int rows;
        private readonly int columns;

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            
            board = new ICell[rows, columns];

            for (var r = 0; r < rows; r++)
            {
                for (var c = 0; c < columns; c++)
                {
                    board[r, c] = new Cell(CellType.Empty, " ");
                }
            }
        }

        public int Rows => rows;
        public int Columns => columns;

        public Tuple<int, int> PlacePlayerChip(ICell cell, int column)
        {
            if ((column < 0) || (column >= columns)) throw new InvalidMoveException("invalid column identifier");

            var row = GetPlaceblePosition(column);
            if (row < 0)
            {
                return new Tuple<int, int>(-1, -1);
            }
            board[row, column] = cell;
            return new Tuple<int, int>(row, column);
        }

        public void Print()
        {
            Console.WriteLine();
            var headerData = string.Join(" | ", Enumerable.Range(0, Columns));
            Console.WriteLine($"| {headerData} |");
            for (int r = 0; r < rows; r++)
            {
                var displayRowData = string.Join(" | ", GetRow(r).Select(x => x.Print()));
                Console.WriteLine($"| {displayRowData} |");
            }
            Console.WriteLine();
        }


        private IEnumerable<ICell> GetRow(int r)
        {
            var res = new List<ICell>();
            for (var c=0; c< columns; c++)
            {
                res.Add(board[r, c]);
            }
            return res;
        }

        private int GetPlaceblePosition(int column)
        {
            for (int row = rows-1; row >= 0; row--)
            {
                if (board[row, column].CellType == CellType.Empty)
                {
                    return row;
                }
            }
            return -1;
        }

        public IEnumerable<ICell> GetCellInRange(IEnumerable<Tuple<int, int>> range)
        {
            var res = new List<ICell>();
            foreach (var x in range)
            {
                res.Add(board[x.Item1, x.Item2]);
            }
            return res;
        }

        public IEnumerable<int> GetAvailableColumns()
        {
            var res = new List<int>();
            for (int c = 0; c < columns; c++)
            {
                if (board[0, c].CellType == CellType.Empty)
                {
                    res.Add(c);
                }
            }
            return res;
        }
    }
}
