using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public enum CellType
    {
        Empty,
        Red,
        Yellow
    }

    public interface ICell
    {
        CellType CellType { get; }

        string Print();
    }
}
