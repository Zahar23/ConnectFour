using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Cell : ICell
    {
        private readonly CellType cellType;
        private readonly string displayString;

        public Cell (CellType cellType, string displayString)
        {
            this.cellType = cellType;
            this.displayString = displayString;


        }

        public CellType CellType => cellType;

        public string Print() => displayString;
    }
}
