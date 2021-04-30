using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            var gg = new Game
                (
                new Board(6,7), 
                new Matrix(6,7), 
                new Player("player-X"), 
                new Player("player-O")
                );

            gg.Run();
        }
    }
}
