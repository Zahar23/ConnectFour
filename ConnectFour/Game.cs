using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class Game : IGame
    {
        private readonly IBoard board;
        private readonly IMatrix matrix;

        private readonly IPlayer[] players;
        private int currentPlayer;

        private const int ChipsInTheRow = 4;

        public Game
            (
            IBoard board,
            IMatrix matrix,
            IPlayer player1,
            IPlayer player2
            )
        {

            this.board = board;
            this.matrix = matrix;

            players = new IPlayer[] { player1, player2 };
            currentPlayer = 0;
        }

        public void Run()
        {
            while (true)
            {
                board.Print();

                var columns = board.GetAvailableColumns();

                if (!columns.Any())
                {
                    board.Print();
                    Console.WriteLine("No more possible moves. Game over. Nobody wins");
                    break;
                }

                var selection = players[currentPlayer].MakeMove(columns);
                if (selection == -1)
                {
                    board.Print();
                    Console.WriteLine($"You gave up. Player {players[GetNextPlayer()].Id} wins.");
                    break;
                }

                var chip = GetChip();

                var placedPosition = board.PlacePlayerChip(chip, selection);
                if (placedPosition.Item1 == -1)
                {
                    board.Print();
                    Console.WriteLine($"Sorry something went wrong. Please come back later.");
                    break;
                }

                if (GameOver(chip.CellType, placedPosition.Item1, placedPosition.Item2))
                {
                    board.Print();
                    Console.WriteLine($"!!! Player {players[currentPlayer].Id} WON !!!");
                    break;
                }

                currentPlayer = GetNextPlayer();
            }
        }

        private bool GameOver(CellType cellType, int row, int column)
        {

            var leftCells = board.GetCellInRange(matrix.GetLeftNeighbors(row, column, ChipsInTheRow - 1));
            var rightCells = board.GetCellInRange(matrix.GetRightNeighbors(row, column, ChipsInTheRow - 1));

            var horizontalMatches = CountContinuesMatches(cellType, leftCells) + 
                                    CountContinuesMatches(cellType, rightCells);

            if (horizontalMatches+1 == ChipsInTheRow)
            {
                return true;
            }

            var topDownCells = board.GetCellInRange(matrix.GetBottomNeighbors(row, column, ChipsInTheRow - 1));
            var topDownMatches = CountContinuesMatches(cellType, topDownCells);
            
            if (topDownMatches + 1 == ChipsInTheRow)
            {
                return true;
            }

            var topLeftCells = board.GetCellInRange(matrix.GetTopLeftNeighbors(row, column, ChipsInTheRow - 1));
            var bottomRightCells = board.GetCellInRange(matrix.GetBottomRightNeighbors(row, column, ChipsInTheRow - 1));

            var topLeftBottomRightMatches = CountContinuesMatches(cellType, topLeftCells) +
                                            CountContinuesMatches(cellType, bottomRightCells);

            if (topLeftBottomRightMatches + 1 == ChipsInTheRow)
            {
                return true;
            }

            var topRighCells = board.GetCellInRange(matrix.GetTopRightNeighbors(row, column, ChipsInTheRow - 1));
            var bottomLeftCells = board.GetCellInRange(matrix.GetBottomLeftNeighbors(row, column, ChipsInTheRow - 1));

            var topRightBottomLeftMatches = CountContinuesMatches(cellType, topRighCells) +
                                            CountContinuesMatches(cellType, bottomLeftCells);
            
            if (topRightBottomLeftMatches +1 == ChipsInTheRow)
            {
                return true;
            }
            return false;
        }

        private Cell GetChip()
        {
            if (currentPlayer == 0)
            {
                return new Cell(CellType.Red, "X");
            }
            else
            {
                return new Cell(CellType.Yellow, "O");
            }
        }

        private int GetNextPlayer()
        {
            if (currentPlayer == 0)
                return 1;
            else
                return 0;
        }

        private int CountContinuesMatches(CellType cellType, IEnumerable<ICell> cells)
        {
            int matched = 0;
            foreach (var x in cells)
            {
                if (x.CellType != cellType)
                {
                    break;
                }
                ++matched;
            }
            return matched;
}
    }
}
