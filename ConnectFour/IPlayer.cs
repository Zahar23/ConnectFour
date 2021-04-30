using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public interface IPlayer
    {
        string Id { get; }

        int MakeMove(IEnumerable<int> columns);
    }
}
