using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PingPong
{
    class PingPong
    {
        static int firstPlayerPadSize = 4;
        static int secondPlayerPadSize = 4;
        //Coordinates of the ball
        static int ballPositionX = 0;
        static int ballPositionY = 0;
        //Determines the ball direction of moving
        static bool BallDirectionUp = true;
        static bool BallDirectionRight = true;
        //Positions of the players
        static int firstPlayerPosition = 0;
        static int secondPlayerPosition = 0;
        static int firstPlayerPoints = 0;
        static int secondPlayerPoints = 0;
        static Random randomGenerator = new Random();

        static void SetBallAtTheMiddle()
        {
            ballPositionY = Console.WindowHeight / 2;
            ballPositionX = Console.WindowWidth / 2;
        }

        static void MoveBall()
        {
            if (ballPositionY == 0)
            {
                BallDirectionUp = false;
            }
            if (ballPositionY == Console.WindowHeight - 1)
            {
                BallDirectionUp = true;
            }
            if (BallDirectionUp == true)
            {
                ballPositionY--;
            }
            else
            {
                ballPositionY++;
            }
            if (ballPositionX == Console.WindowWidth - 1)
            {
                SetBallAtTheMiddle();
                BallDirectionRight = false;
                firstPlayerPoints++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("First Player Wins!!!!");
                Console.ReadKey();
            }
            if (ballPositionX == 0)
            {
                SetBallAtTheMiddle();
                BallDirectionRight = true;
                secondPlayerPoints++;
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2);
                Console.WriteLine("Second Player Wins!!!!");
                Console.ReadKey();
            }
            if (ballPositionX < 3)
            {
                if (ballPositionY >= firstPlayerPosition && ballPositionY < firstPlayerPosition + firstPlayerPadSize)
                {
                    BallDirectionRight = true;
                }
            }
            if (ballPositionX >= Console.WindowWidth - 3)
            {
                if (ballPositionY >= secondPlayerPosition && ballPositionY < secondPlayerPosition + firstPlayerPadSize)
                {
                    BallDirectionRight = false;    
                }
                
            }
            if (BallDirectionRight == true)
            {
                ballPositionX++;
            }
            else
            {
                ballPositionX--;
            }
        }

        private static void MoveFirstPlayerUp()
        {
            if (firstPlayerPosition > 0)
            {
                firstPlayerPosition--;
            }
            
        }

        private static void MoveFirstPlayerDown()
        {
            if (firstPlayerPosition < Console.WindowHeight - firstPlayerPadSize)
            {
                firstPlayerPosition++;    
            }
            
        }

        private static void MoveSecondPlayerUp()
        {
            if (secondPlayerPosition > 0)
            {
                secondPlayerPosition--;
            }

        }

        private static void MoveSecondPlayerDown()
        {
            if (secondPlayerPosition < Console.WindowHeight - secondPlayerPadSize)
            {
                secondPlayerPosition++;
            }

        }

        static void SecondPlayerAIMove()
        {
           int randomNumber = randomGenerator.Next(1, 101);
           /*if (randomNumber == 0)
           {
               MoveSecondPlayerUp();
           }
           else
	        {
                MoveSecondPlayerDown();
	        }*/

           if (randomNumber <= 90)
           {


               if (BallDirectionUp == true)
               {
                   MoveSecondPlayerUp();
               }
               else
               {
                   MoveSecondPlayerDown();
               }
           }
        }

        static void PrintResult()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 2,0);
            Console.WriteLine("{0} - {1}",firstPlayerPoints,secondPlayerPoints);
        }

        static void DrawBall()
        {
            PrintAtPosition(ballPositionX, ballPositionY, '@', ConsoleColor.Blue);
        }

        static void SetInitialPosition()
        {
            firstPlayerPosition = Console.WindowHeight/2 -firstPlayerPadSize/2;
            secondPlayerPosition = Console.WindowHeight / 2 - secondPlayerPadSize / 2;
            SetBallAtTheMiddle();
        }

        static void RemoveScrollBars()
        {
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
        }

        static void PrintAtPosition(int x, int y, char c,ConsoleColor color = ConsoleColor.Blue)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.ForegroundColor = color;
        }

        


        static void DrawFirstPlayer()
        {
            for (int y = firstPlayerPosition; y < firstPlayerPadSize+firstPlayerPosition ; y++)
            {
                PrintAtPosition(0, y, '|', ConsoleColor.Blue);
                PrintAtPosition(1, y, '|', ConsoleColor.Blue);  
            }
        }

        static void DrawSecondPlayer()
        {
            for (int y = secondPlayerPosition; y < secondPlayerPadSize + secondPlayerPosition; y++)
            {
                PrintAtPosition(Console.WindowWidth - 1, y, '|', ConsoleColor.Blue);
                PrintAtPosition(Console.WindowWidth - 2, y, '|', ConsoleColor.Blue);
            }
        }

        static void Main(string[] args)
        {
            RemoveScrollBars();

            SetInitialPosition();

            while (true)
            {

                //Move first player
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    if (keyInfo.Key == ConsoleKey.UpArrow)
                    {
                        MoveFirstPlayerUp();
                       
                    }
                    if (keyInfo.Key == ConsoleKey.DownArrow)
                    {
                        MoveFirstPlayerDown();
                       
                    }
                }
                //Move second player
                SecondPlayerAIMove();
                //Move the ball
                MoveBall();
                //Redraw all
                //-clear all
                Console.Clear();
                //-draw first plyer
                DrawFirstPlayer();
                //-draw second player
                DrawSecondPlayer();
                //-draw ball
                DrawBall();
                //-print result
                PrintResult();
                //Sleep
                Thread.Sleep(60);
            }


        }

       

       

        
    }
}
