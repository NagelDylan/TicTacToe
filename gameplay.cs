using System;

namespace gameplay.cs
{
    class MainClass
    {
        const int PLAYER_ONE = 0;
        const int PLAYER_TWO = 1;

        const bool YES = true;

        const int X_AXIS = 0;
        const int Y_AXIS = 1;

        public static void Main(string[] args)
        {
            string[,] boardPlacements = new string[3, 3];
            for(int i = 0; i < boardPlacements.GetLength(0); i ++)
            {
                for(int x = 0; x < boardPlacements.GetLength(1); x++)
                {
                    boardPlacements[i, x] = " ";
                }
            }

            int playerTurn = PLAYER_ONE;

            bool isGamePlaying = YES;

            bool isSpotTaken = false;

            string userMove = "";

            int[] userLoc = new int[] { 1, 1 };

            boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "?";

            while (isGamePlaying)
            {
                Console.Clear();

                Console.WriteLine("Enter W, A, S or D followed by ENTER to move placement. Enter P followed by ENTER to place your piece\n\n\n");

                Console.WriteLine("Player " + (playerTurn + 1) + "'s turn\n\n");

                Console.WriteLine("       │       │");
                Console.WriteLine("   " + boardPlacements[0, 0] + "   │   " + boardPlacements[1, 0] + "   │   " + boardPlacements[2, 0] + "   ");
                Console.WriteLine("       │       │");
                Console.WriteLine("───────┼───────┼───────");
                Console.WriteLine("       │       │");
                Console.WriteLine("   " + boardPlacements[0, 1] + "   │   " + boardPlacements[1, 1] + "   │   " + boardPlacements[2, 1] + "   ");
                Console.WriteLine("       │       │");
                Console.WriteLine("───────┼───────┼───────");
                Console.WriteLine("       │       │");
                Console.WriteLine("   " + boardPlacements[0, 2] + "   │   " + boardPlacements[1, 2] + "   │   " + boardPlacements[2, 2] + "   ");
                Console.WriteLine("       │       │");

                if (isSpotTaken)
                {
                    Console.WriteLine("\n\nINVALID LOCATION! TRY AGAIN!");

                    isSpotTaken = false;
                }

                userMove = Console.ReadLine();

                if (userMove == "w" && userLoc[Y_AXIS] != 0)
                {
                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals("?"))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = " ";
                    }

                    userLoc[Y_AXIS]--;

                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals(" "))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "?";
                    }
                }
                else if (userMove == "s" && userLoc[Y_AXIS] != 2)
                {
                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals("?"))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = " ";
                    }

                    userLoc[Y_AXIS]++;

                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals(" "))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "?";
                    }
                }
                else if (userMove == "a" && userLoc[X_AXIS] != 0)
                {
                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals("?"))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = " ";
                    }

                    userLoc[X_AXIS]--;

                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals(" "))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "?";
                    }
                }
                else if (userMove == "d" && userLoc[X_AXIS] != 2)
                {
                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals("?"))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = " ";
                    }

                    userLoc[X_AXIS]++;

                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals(" "))
                    {
                        boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "?";
                    }
                }
                else if (userMove == "p")
                {
                    if (boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]].Equals("?"))
                    {
                        if (playerTurn == PLAYER_ONE)
                        {
                            boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "X";

                            playerTurn = PLAYER_TWO;
                        }
                        else
                        {
                            boardPlacements[userLoc[X_AXIS], userLoc[Y_AXIS]] = "O";

                            playerTurn = PLAYER_ONE;
                        }
                    }
                    else
                    {
                        isSpotTaken = true;
                    }
                }

                //top horizonal
                if (boardPlacements[0, 0].Equals("O") && boardPlacements[1, 0].Equals("O") && boardPlacements[2, 0].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                else if (boardPlacements[0, 0].Equals("X") && boardPlacements[1, 0].Equals("X") && boardPlacements[2, 0].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                //left to right diagonal
                else if (boardPlacements[0, 0].Equals("O") && boardPlacements[1, 1].Equals("O") && boardPlacements[2, 2].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                else if (boardPlacements[0, 0].Equals("X") && boardPlacements[1, 1].Equals("X") && boardPlacements[2, 2].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                //right to left diagonal
                else if (boardPlacements[0, 2].Equals("X") && boardPlacements[1, 1].Equals("X") && boardPlacements[2, 0].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                else if (boardPlacements[0, 2].Equals("O") && boardPlacements[1, 1].Equals("O") && boardPlacements[2, 0].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                //bottom horizontal
                else if (boardPlacements[0, 2].Equals("X") && boardPlacements[1, 2].Equals("X") && boardPlacements[2, 2].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                else if (boardPlacements[0, 2].Equals("O") && boardPlacements[1, 2].Equals("O") && boardPlacements[2, 2].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                //middle horizonal
                else if (boardPlacements[0, 1].Equals("X") && boardPlacements[1, 1].Equals("X") && boardPlacements[2, 1].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                else if (boardPlacements[0, 1].Equals("O") && boardPlacements[1, 1].Equals("O") && boardPlacements[2, 1].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                //left vertical
                else if (boardPlacements[0, 0].Equals("X") && boardPlacements[0, 1].Equals("X") && boardPlacements[0, 2].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                else if (boardPlacements[0, 0].Equals("O") && boardPlacements[0, 1].Equals("O") && boardPlacements[0, 2].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                //middle vertical
                else if (boardPlacements[1, 0].Equals("X") && boardPlacements[1, 1].Equals("X") && boardPlacements[1, 2].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                else if (boardPlacements[1, 0].Equals("O") && boardPlacements[1, 1].Equals("O") && boardPlacements[1, 2].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
                //right vertical
                else if (boardPlacements[2, 0].Equals("X") && boardPlacements[2, 1].Equals("X") && boardPlacements[2, 2].Equals("X"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER ONE WINS!!!\n\n");
                }
                else if (boardPlacements[2, 0].Equals("O") && boardPlacements[2, 1].Equals("O") && boardPlacements[2, 2].Equals("O"))
                {
                    isGamePlaying = false;

                    Console.Clear();
                    Console.WriteLine("PLAYER TWO WINS!!!\n\n");
                }
            }

            Console.WriteLine("       │       │");
            Console.WriteLine("   " + boardPlacements[0, 0] + "   │   " + boardPlacements[1, 0] + "   │   " + boardPlacements[2, 0] + "   ");
            Console.WriteLine("       │       │");
            Console.WriteLine("───────┼───────┼───────");
            Console.WriteLine("       │       │");
            Console.WriteLine("   " + boardPlacements[0, 1] + "   │   " + boardPlacements[1, 1] + "   │   " + boardPlacements[2, 1] + "   ");
            Console.WriteLine("       │       │");
            Console.WriteLine("───────┼───────┼───────");
            Console.WriteLine("       │       │");
            Console.WriteLine("   " + boardPlacements[0, 2] + "   │   " + boardPlacements[1, 2] + "   │   " + boardPlacements[2, 2] + "   ");
            Console.WriteLine("       │       │");
        }
    }
}