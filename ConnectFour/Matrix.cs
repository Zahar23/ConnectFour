using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Matrix : IMatrix
    {
        /// <summary>
        /// Tuple item1 - is row
        /// Tuple item2 - is column
        /// Matrix is 0 based coordinate system
        /// </summary>

        private readonly int rows;
        private readonly int columns;

        public int Rows => rows;

        public int Columns => columns;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public IEnumerable<Tuple<int, int>> GetMatrix()
        {
            var res = new List<Tuple<int, int>>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    res.Add(new Tuple<int, int>(r, c));
                }
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetRow(int row)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));

            var res = new List<Tuple<int, int>>();
            for (int c = 0; c < columns; c++)
            {
                res.Add(new Tuple<int, int>(c, row));
            }

            return res;
        }

        public IEnumerable<Tuple<int, int>> GetColumn(int column)
        {
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();
            for (int r = 0; r < rows; r++)
            {
                res.Add(new Tuple<int, int>(r, column));
            }

            return res;
        }

        public IEnumerable<Tuple<int, int>> GetLeftNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));


            var res = new List<Tuple<int, int>>();

            for (int c = column - 1; c >= 1 && res.Count <= max; c--)
            {
                res.Add(new Tuple<int, int>(row, c));
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetRightNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();

            for (int c = column + 1; c < columns && res.Count <= max; c++)
            {
                res.Add(new Tuple<int, int>(row, c));
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetBottomNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();

            for (int r = row + 1; r < rows && res.Count <= max; r++)
            {
                res.Add(new Tuple<int, int>(r, column));
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetTopLeftNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();
            for (int r = row - 1; r > 0 && res.Count <= max; r--)
            {
                for (int c = column - 1; c > 0 && res.Count <= max; c--)
                {
                    res.Add(new Tuple<int, int>(r, c));
                }
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetTopRightNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();
            for (int r = row - 1; r > 0 && res.Count <= max; r--)
            {
                for (int c = column + 1; c < columns && res.Count <= max; c++)
                {
                    res.Add(new Tuple<int, int>(r, c));
                }
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetBottomLeftNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();
            for (int r = row + 1; r < rows && res.Count <= max; r++)
            {
                for (int c = column - 1; c > 0 && res.Count <= max; c--)
                {
                    res.Add(new Tuple<int, int>(r, c));
                }
            }
            return res;
        }

        public IEnumerable<Tuple<int, int>> GetBottomRightNeighbors(int row, int column, int max)
        {
            if ((row < 0) || (row >= rows)) throw new ArgumentOutOfRangeException(nameof(row));
            if ((column < 0) || (column >= columns)) throw new ArgumentOutOfRangeException(nameof(column));

            var res = new List<Tuple<int, int>>();
            for (int r = row + 1; r < rows && res.Count <= max; r++)
            {
                for (int c = column + 1; c < columns && res.Count <= max; c++)
                {
                    res.Add(new Tuple<int, int>(r, c));
                }
            }
            return res;
        }
    }
}
