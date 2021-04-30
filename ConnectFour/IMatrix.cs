using System;
using System.Collections.Generic;

namespace ConnectFour
{
    public interface IMatrix
    {
        int Rows { get; }
        int Columns { get; }

        IEnumerable<Tuple<int, int>> GetMatrix();
        IEnumerable<Tuple<int, int>> GetRow(int row);
        IEnumerable<Tuple<int, int>> GetColumn(int column);

        IEnumerable<Tuple<int, int>> GetBottomNeighbors(int row, int column, int max);

        IEnumerable<Tuple<int, int>> GetLeftNeighbors(int row, int column, int max);
        IEnumerable<Tuple<int, int>> GetRightNeighbors(int row, int column, int max);

        IEnumerable<Tuple<int, int>> GetBottomLeftNeighbors(int row, int column, int max);
        IEnumerable<Tuple<int, int>> GetBottomRightNeighbors(int row, int column, int max);
      
        IEnumerable<Tuple<int, int>> GetTopLeftNeighbors(int row, int column, int max);
        IEnumerable<Tuple<int, int>> GetTopRightNeighbors(int row, int column, int max);
    }
}