using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Player : IPlayer
    {
        private readonly string id;

        public Player(string id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));

            this.id = id;
        }

        public string Id => id;

      

        public int MakeMove(IEnumerable<int> columns)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine();
                    Console.Write($"[{id}]: select column [{string.Join(",", columns)}]: ");
                    var key = Console.ReadKey(false);
                    var selection = System.Convert.ToInt32(key.KeyChar) - '0';
                    if (columns.Contains(selection))
                    {
                        Console.WriteLine();
                        return selection;
                    }
                    if (key.KeyChar == 'q')
                    {
                        Console.WriteLine();
                        return -1;
                    }
                    Console.WriteLine();
                    Console.Beep();
                }
                catch(FormatException)
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }
    }
}
