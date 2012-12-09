using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HackerrankTicTacToe
{
    using System;
    using System.Linq;
    class Solution
    {
        public static string Position1 = "0 0";
        public static string Position2 = "0 1";
        public static string Position3 = "0 2";
        public static string Position4 = "1 0";
        public static string Position5 = "1 1";
        public static string Position6 = "1 2";
        public static string Position7 = "2 0";
        public static string Position8 = "2 1";
        public static string Position9 = "2 2";
        
        static void nextMove(String player, String[] board)
        {
            if (player == "X")
            {
                PlayXStrategy(board);
            }else
            {
                PlayOStrategy(board);
            }
        }

        private static int NumberOfCharacterOnBoard(string[] board, string character)
        {
            string row0 = board[0];
            string row1 = board[1];
            string row2 = board[2];

            int sum = 0;

            sum += row0.Count(f => f == Convert.ToChar(character));
            sum += row1.Count(f => f == Convert.ToChar(character));
            sum += row2.Count(f => f == Convert.ToChar(character));

            return sum;
        }

        private static string CenterSquare(string[] board)
        {
            string row1 = board[1];
            return row1.Substring(1, 1);
        }

        private static string TopLeftSquare(string[] board)
        {
            string row = board[0];
            return row.Substring(0, 1);
        }

        private static string TopRightSquare(string[] board)
        {
            string row = board[0];
            return row.Substring(2, 1);
        }

        private static string BottomLeftSquare(string[] board)
        {
            string row = board[2];
            return row.Substring(0, 1);
        }

        private static string BottomRightSquare(string[] board)
        {
            string row = board[2];
            return row.Substring(2, 1);
        }

        private static string EdgeLeftSquare(string[] board)
        {
            string row = board[1];
            return row.Substring(0, 1);
        }

        private static string EdgeRightSquare(string[] board)
        {
            string row = board[1];
            return row.Substring(2, 1);
        }

        private static string EdgeTopSquare(string[] board)
        {
            string row = board[0];
            return row.Substring(1, 1);
        }

        private static string EdgeBottomSquare(string[] board)
        {
            string row = board[2];
            return row.Substring(1, 1);
        }

        private static int CountOfCornerPlays(string Player, string[] board)
        {
            int count = 0;

            if (TopLeftSquare(board) == Player)
            {
                count++;
            }
 
            if (TopRightSquare(board) == Player)
            {
                count++;
            }

            if (BottomLeftSquare(board) == Player)
            {
                count++;
            }

            if (BottomRightSquare(board) == Player)
            {
                count++;
            }

            return count;
        }

        private static string CheckForImpendingDoom(string opponent, String[] board)
        {
            string rightHorizontal = board[0].Substring(0, 1) + board[1].Substring(1, 1) + board[2].Substring(2, 1);
            
            if (rightHorizontal.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (rightHorizontal.Count(f => f == Convert.ToChar("_")) == 1)
                {
                    int index = rightHorizontal.IndexOf(Convert.ToChar("_"));

                    switch (index)
                    {
                        case 0:
                        {
                            return "0 0";
                        }
                        case 1:
                        {
                            return "1 1";
                        }
                        case 2:
                        {
                            return "2 2";
                        }
                    }
                }
            }

            //Check left horizontal

            string leftHorizontal = board[0].Substring(2, 1) + board[1].Substring(1, 1) + board[2].Substring(0, 1);
            if (leftHorizontal.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (leftHorizontal.Count(f => f == Convert.ToChar("_")) == 1)
                {
                    int index = leftHorizontal.IndexOf(Convert.ToChar("_"));

                    switch (index)
                    {
                        case 0:
                            {
                                return "0 2";
                            }
                        case 1:
                            {
                                return "1 1";
                            }
                        case 2:
                            {
                                return "2 0";
                            }
                    }
                }
            }

            //check horizontal doom

            string horizontal0 = board[0];
            string horizontal1 = board[1];
            string horizontal2 = board[2];

            if (horizontal0.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (horizontal0.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", 0, horizontal0.IndexOf("_"));
            }

            if (horizontal1.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (horizontal1.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", 1, horizontal1.IndexOf("_"));
            }

            if (horizontal2.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (horizontal2.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", 2, horizontal2.IndexOf("_"));
            }

            //check vertical doom
            string vertical1 = board[0].Substring(0, 1) + board[1].Substring(0, 1) + board[2].Substring(0, 1);
            string vertical2 = board[0].Substring(1, 1) + board[1].Substring(1, 1) + board[2].Substring(1, 1);
            string vertical3 = board[0].Substring(2, 1) + board[1].Substring(2, 1) + board[2].Substring(2, 1);

            if (vertical1.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (vertical1.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", vertical1.IndexOf("_"), 0);
            }

            if (vertical2.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (vertical2.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", vertical2.IndexOf("_"), 1);
            }

            if (vertical3.Count(f => f == Convert.ToChar(opponent)) == 2)
            {
                if (vertical3.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", vertical3.IndexOf("_"), 2);
            }

            return "";
        }

        private static string FindOptimalMove(String[] board, String player)
        {

            string horizontal0 = board[0];
            string horizontal1 = board[1];
            string horizontal2 = board[2];

            if (horizontal0.Count(f => f == Convert.ToChar(player)) == 2)
            {
                if (horizontal0.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", 0, horizontal0.IndexOf("_"));
            }
            if (horizontal1.Count(f => f == Convert.ToChar(player)) == 2)
            {
                if (horizontal1.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", 1, horizontal1.IndexOf("_"));
            }

            if (horizontal2.Count(f => f == Convert.ToChar(player)) == 2)
            {
                if (horizontal2.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", 2, horizontal2.IndexOf("_"));
            }

            //check vertical doom
            string vertical1 = board[0].Substring(0, 1) + board[1].Substring(0, 1) + board[2].Substring(0, 1);
            string vertical2 = board[0].Substring(1, 1) + board[1].Substring(1, 1) + board[2].Substring(1, 1);
            string vertical3 = board[0].Substring(2, 1) + board[1].Substring(2, 1) + board[2].Substring(2, 1);

            if (vertical1.Count(f => f == Convert.ToChar(player)) == 2)
            {
                if (vertical1.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", vertical1.IndexOf("_"), 0);
            }

            if (vertical2.Count(f => f == Convert.ToChar(player)) == 2)
            {
                if (vertical2.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", vertical2.IndexOf("_"), 1);
            }

            if (vertical3.Count(f => f == Convert.ToChar(player)) == 2)
            {
                if (vertical3.Count(f => f == Convert.ToChar("_")) == 1)
                    return String.Format("{0} {1}", vertical3.IndexOf("_"), 2);
            }

            //Check right diagonal

            string rightDiagonal = board[0].Substring(0, 1) + board[1].Substring(1, 1) + board[2].Substring(2, 1);
            if (rightDiagonal.Count(f => f == Convert.ToChar(player)) == 2)
            {
                int index = rightDiagonal.IndexOf(Convert.ToChar("_"));
                if (rightDiagonal.Count(f => f == Convert.ToChar("_")) == 1)
                {
                    switch (index)
                    {
                        case 0:
                            {
                                return "0 0";
                            }
                        case 1:
                            {
                                return "1 1";
                            }
                        case 2:
                            {
                                return "2 2";
                            }
                    }
                }
            }

            //Check left diagonal
            string leftDiagonal = board[0].Substring(2, 1) + board[1].Substring(1, 1) + board[2].Substring(0, 1);
            if (leftDiagonal.Count(f => f == Convert.ToChar(player)) == 2)
            {
                int index = leftDiagonal.IndexOf(Convert.ToChar("_"));
                if (leftDiagonal.Count(f => f == Convert.ToChar("_")) == 1)
                {
                    switch (index)
                    {
                        case 0:
                            {
                                return "0 2";
                            }
                        case 1:
                            {
                                return "1 1";
                            }
                        case 2:
                            {
                                return "2 0";
                            }
                    }
                }
            }
            return "";
        }
        
        private static string GetOpponentString(string player)
        {
            if (player == "X")
            {
                return "O";
            }

            return "X";

        }

        private static int NumberOfCharacterInCorners(string player, string[] board)
        {
            int count = 0;

            if (TopLeftSquare(board) == player)
            {
                count++;
            }

            if (TopRightSquare(board) == player)
            {
                count++;
            }

            if (BottomLeftSquare(board) == player)
            {
                count++;
            }

            if (BottomRightSquare(board) == player)
            {
                count++;
            }

            return count;
        }

        private static int NumberOfCharacterInEdges(string player, string[] board)
        {
            int count = 0;

            if (EdgeLeftSquare(board) == player)
            {
                count++;
            }

            if (EdgeTopSquare(board) == player)
            {
                count++;
            }

            if (EdgeRightSquare(board) == player)
            {
                count++;
            }

            if (EdgeBottomSquare(board) == player)
            {
                count++;
            }

            return count;
        }
        
        private static void PlayXStrategy(string[] board)
        {
            int NumberOfXs = NumberOfCharacterOnBoard(board, "X");

            if (NumberOfXs == 0)
            {
                Console.WriteLine(Position1);
                return;
            }

            if (NumberOfXs == 1)
            {
                //O Plays Center Square
                if (CenterSquare(board) == "O")
                {
                    Console.WriteLine(Position9);
                    return;
                }

                //O Plays to a Corner Square
                if (TopRightSquare(board) == "O")
                {
                    Console.WriteLine(Position7);
                    return;
                }

                if (BottomLeftSquare(board) == "O")
                {
                    Console.WriteLine(Position3);
                    return;
                }

                if (BottomRightSquare(board) == "O")
                {
                    Console.WriteLine(Position7);
                    return;
                }

                //O Plays to an Edge Square

                if (EdgeTopSquare(board) == "O" || EdgeRightSquare(board) == "O" || EdgeLeftSquare(board) == "O" || EdgeBottomSquare(board) == "O")
                {
                    Console.WriteLine(Position5);
                    return;
                }

            }

            if (NumberOfXs == 2)
            {
                //O Starts with Center Square
                if (CenterSquare(board) == "O")
                {
                    string move = CheckForImpendingDoom("O", board);

                    if (move != "")
                    {
                        Console.WriteLine(move);
                    }
                    else
                    {
                        move = FindOptimalMove(board, "X");
                        {
                            Console.WriteLine(move);
                        }
                    }
                    return;
                }

                //O Starts with Corner Square
                int CountOfCornerOs = CountOfCornerPlays("O", board);

                if (CountOfCornerOs == 1)
                {
                    if (TopRightSquare(board) == "_")
                    {
                        Console.WriteLine(Position3);
                        return;
                    }

                    if (BottomLeftSquare(board) == "_")
                    {
                        Console.WriteLine(Position7);
                        return;
                    }

                    if (BottomRightSquare(board) == "_")
                    {
                        Console.WriteLine(Position9);
                        return;
                    }
                }

                //O Starts with Edge Square
                if (EdgeTopSquare(board) == "O" || EdgeRightSquare(board) == "O" || EdgeLeftSquare(board) == "O" || EdgeBottomSquare(board) == "O")
                {
                    if (CenterSquare(board) == "X")
                    {
                        string move = CheckForImpendingDoom("O", board);
                        if (move != "")
                        {
                            Console.WriteLine(move);
                            return;
                        }

                        //x the corner not bordered by an O

                        if (EdgeTopSquare(board) == "_" && EdgeRightSquare(board) == "_")
                        {
                            Console.WriteLine(Position3);
                            return;
                        }

                        if (EdgeRightSquare(board) == "_" && EdgeBottomSquare(board) == "_")
                        {
                            Console.WriteLine(Position9);
                            return;
                        }

                        if (EdgeBottomSquare(board) == "_" && EdgeLeftSquare(board) == "_")
                        {
                            Console.WriteLine(Position7);
                            return;
                        }
                    }
                }
            }

            if (NumberOfXs == 3)
            {
                string move = CheckForImpendingDoom("O", board);

                if (move != "")
                {
                    Console.WriteLine(move);
                }
                else
                {
                    move = FindOptimalMove(board, "X");
                    {
                        Console.WriteLine(move);
                    }
                }
            }

            if (NumberOfXs == 4)
            {
                string move = CheckForImpendingDoom("O", board);

                if (move != "")
                {
                    Console.WriteLine(move);
                }
                else
                {
                    move = FindOptimalMove(board, "X");
                    {
                        Console.WriteLine(move);
                    }
                }
            }
        }

        private static void PlayOStrategy(string[] board)
        {
            if (NumberOfCharacterOnBoard(board, "O") == 0)
            {
                if (CenterSquare(board) == "_")
                {
                    Console.WriteLine(Position5);
                    return;
                }

                if (CenterSquare(board) == "X")
                {
                    
                }

                Console.WriteLine(Position1);
                return;
            }

            if (NumberOfCharacterOnBoard(board, "O") == 1)
            {
                //Second X threatens a win
                string move = CheckForImpendingDoom("X", board);
                if (move != "")
                {
                    Console.WriteLine(move);
                    return;
                }else
                {
                    if (CenterSquare(board) == "X")
                    {
                        if (TopLeftSquare(board) == "_")
                        {
                            Console.WriteLine(Position1);
                            return;
                        }

                        if (TopRightSquare(board) == "_")
                        {
                            Console.WriteLine(Position3);
                            return;
                        }

                        if (BottomLeftSquare(board) == "_")
                        {
                            Console.WriteLine(Position7);
                            return;
                        }

                        if (BottomRightSquare(board) == "_")
                        {
                            Console.WriteLine(Position9);
                            return;
                        }
                    }
                }

                if (NumberOfCharacterInCorners("X", board) == 2)
                {
                    if (EdgeBottomSquare(board) == "_")
                    {
                        Console.WriteLine(Position8);
                        return;
                    }

                    if (EdgeLeftSquare(board) == "_")
                    {
                        Console.WriteLine(Position4);
                        return;
                    }

                    if (EdgeRightSquare(board) == "_")
                    {
                        Console.WriteLine(Position6);
                        return;
                    }

                    if (EdgeTopSquare(board) == "_")
                    {
                        Console.WriteLine(Position2);
                        return;
                    }
                }

                if (NumberOfCharacterInCorners("X",board) == 1 && NumberOfCharacterInEdges("X", board) == 1)
                {
                    //O the corner square caddy-corner to the corner X.
                    if (TopLeftSquare(board) == "X")
                    {
                        Console.WriteLine(Position9);
                        return;
                    }

                    if (TopRightSquare(board) == "X")
                    {
                        Console.WriteLine(Position7);
                        return;
                    }

                    if (BottomLeftSquare(board) == "X")
                    {
                        Console.WriteLine(Position3);
                        return;
                    }

                    if (BottomRightSquare(board) == "X")
                    {
                        Console.WriteLine(Position1);
                        return;
                    }
                }

                if (NumberOfCharacterInEdges("X", board) == 2)
                {

                    //Caddy Corner Xs
                    if ( TopLeftSquare(board) == "X" && BottomRightSquare(board) == "X")
                    {
                        if (EdgeTopSquare(board) == "_")
                        {
                            Console.WriteLine(Position2);
                            return;
                        }

                        if (EdgeLeftSquare(board) == "_")
                        {
                            Console.WriteLine(Position4);
                            return;
                        }

                        if (EdgeRightSquare(board) == "_")
                        {
                            Console.WriteLine(Position6);
                        }

                        if (EdgeBottomSquare(board) == "_")
                        {
                            Console.WriteLine(Position8);
                        }

                        
                    }


                    /*When both X's border a corner square (draw):
                        O the corner square bordered by the two X's.
                        X must block your threatened win.
                        O any square. Block and draw.*/
                    if (EdgeLeftSquare(board) == "X" && EdgeTopSquare(board) == "X")
                    {
                        Console.WriteLine(Position1);
                        return;
                    }

                    if (EdgeTopSquare(board) == "X" && EdgeRightSquare(board) == "X")
                    {
                        Console.WriteLine(Position3);
                        return;
                    }

                    if (EdgeRightSquare(board) == "X" && EdgeBottomSquare(board) == "X")
                    {
                        Console.WriteLine(Position9);
                        return;
                    }

                    if (EdgeBottomSquare(board) == "X" && EdgeLeftSquare(board) == "X")
                    {
                        Console.WriteLine(Position7);
                        return;
                    }
                    /*When both X's don't border a corner (O wins!):
                    O either of the remaining open edge squares.
                    X must block your threatened win.
                    O either corner square bordered by only one X.
                    Win on your next move. Amazing!*/

                    if (EdgeBottomSquare(board) == "_")
                    {
                        Console.WriteLine(Position8);
                        return;
                    }

                    if (EdgeLeftSquare(board) == "_")
                    {
                        Console.WriteLine(Position4);
                        return;
                    }

                    if (EdgeRightSquare(board) == "_")
                    {
                        Console.WriteLine(Position6);
                        return;
                    }

                    if (EdgeTopSquare(board) == "_")
                    {
                        Console.WriteLine(Position2);
                        return;
                    }
                }
            }

            string Impending = "";
            Impending = CheckForImpendingDoom("X", board);
            if (Impending != "")
            {
                Console.WriteLine(Impending);
                return;
            }

            string Optimal = "";
            Optimal = FindOptimalMove(board, "O");
            if (Optimal != "")
            {
                Console.WriteLine(Optimal);
                return;
            }

            Console.WriteLine(ReturnAnySquare(board));
        }

        private static string ReturnAnySquare(string[] board)
        {
            string move = "";

            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (board[x].Substring(y, 1) == "_")
                    {
                        move = x + " " + y;
                    }
                }
            }

            return move;
        }

        static void Main(String[] args)
        {
            String player;

            //If player is X, I'm the first player.
            //If player is O, I'm the second player.
            player = Console.ReadLine();

            //Read the board now. The board is a 3x3 array filled with X, O or _.
            String[] board = new String[3];
            for (int i = 0; i < 3; i++)
            {
                board[i] = Console.ReadLine();
            }

            nextMove(player, board);

        }
    }
}
