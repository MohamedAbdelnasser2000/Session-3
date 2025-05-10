using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_Tic_Tac_Toe__XO_
{
    class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';

        static void Main(string[] args)
        {

            while (true)
            {
                InitializeBoard();
                PlayGame();

                Console.Write("\nDo you want to play again? (y/n): ");
                string answer = Console.ReadLine().ToLower();
                if (answer != "y")
                    break;
            }

            Console.WriteLine("Thank you for playing!");


        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    board[i, j] = ' ';
        }


        static void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("   0   1   2");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("  -----------");
                Console.Write($"{i} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"| {board[i, j]} ");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("  -----------");
        }


        static void PlayGame()
        {
            bool gameEnded = false;

            while (!gameEnded)
            {
                PrintBoard();
                Console.WriteLine($"\nPlayer {currentPlayer}, it's your turn.");

                int row, col;

                while (true)
                {
                    Console.Write("Enter row (0-2): ");
                    bool validRow = int.TryParse(Console.ReadLine(), out row);
                    Console.Write("Enter column (0-2): ");
                    bool validCol = int.TryParse(Console.ReadLine(), out col);

                    if (!validRow || !validCol || row < 0 || row > 2 || col < 0 || col > 2)
                    {
                        Console.WriteLine("Invalid input. Please enter numbers between 0 and 2.");
                    }
                    else if (board[row, col] != ' ')
                    {
                        Console.WriteLine("That cell is already taken. Try a different one.");
                    }
                    else
                    {
                        break;
                    }
                }

                board[row, col] = currentPlayer;

                if (CheckWinner(currentPlayer))
                {
                    PrintBoard();
                    Console.WriteLine($"\n🎉 Player {currentPlayer} wins!");
                    gameEnded = true;
                }
                else if (IsBoardFull())
                {
                    PrintBoard();
                    Console.WriteLine("\nس It's a draw!");
                    gameEnded = true;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }


        static bool CheckWinner(char player)
        {
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                    return true;
            }

            if ((board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player))
                return true;

            return false;
        }



        static bool IsBoardFull()
        {
            foreach (char cell in board)
                if (cell == ' ')
                    return false;
            return true;
        }
    }
}
