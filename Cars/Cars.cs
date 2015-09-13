using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Cars
{
    struct Car
    {
        public int x;
        public int y;
        public char c;
        public ConsoleColor color;
    }

    

    class Cars
    {

        //Printing position of the cars and so on......
        static void PrintOnPosition(int x, int y, char c, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }
        static void stringPrintOnPosition(int x, int y, string str, ConsoleColor color = ConsoleColor.Magenta)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        static void Main(string[] args)
        {
            double speed = 100.0;
            int playFieldWidth = 5;
            int livesCount = 5;


            //Removing the scrollbar(buffer)
            Console.BufferHeight = Console.WindowHeight = 30;
            Console.BufferWidth = Console.WindowWidth = 30;
            //Positioning the user car(color, x, y, char)
            Car userCar = new Car();
            userCar.x = 2;
            userCar.y = Console.WindowHeight - 1;
            userCar.c = '$';
            userCar.color = ConsoleColor.Blue;

            Random randomGenerator = new Random();

            //Creating other enemy cars
            List<Car> enemyCars = new List<Car>();
            bool colide = false;
            while (true)
            {
                speed++;
               
                if (speed > 250)
                {
                    speed = 250;
                }
                //Move cars
                randomGenerator.Next(1, 5);
                {
                    Car newCar = new Car();
                    newCar.color = ConsoleColor.Green;
                    newCar.x = randomGenerator.Next(0, playFieldWidth);
                    newCar.y = 0;
                    newCar.c = '^';
                    enemyCars.Add(newCar);
                }

                //Move our car(key pressed)

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(true);
                    }
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userCar.x - 1 >= 0)
                        {
                            userCar.x--;
                        }

                    }
                    if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (userCar.x + 1 <= 5)
                        {
                            userCar.x++;
                        }
                    }
                }
                List<Car> newList = new List<Car>();
                for (int i = 0; i < enemyCars.Count; i++)
                {
                    Car oldCar = enemyCars[i];
                    Car newCar = new Car();
                    newCar.x = oldCar.x;
                    newCar.y = oldCar.y + 1;
                    newCar.c = oldCar.c;
                    newCar.color = oldCar.color;
                    //colision
                    if (newCar.y == userCar.y && newCar.x == userCar.x)
                    {
                        
                        livesCount--;
                        colide = true;
                        speed += 10;
                         
                        if (livesCount<=0)
                        {
                            stringPrintOnPosition(8, 7, "GAME OVER!!!", ConsoleColor.Red);
                            stringPrintOnPosition(8, 12, "Press any key to continue!!!!", ConsoleColor.Red);
                            Console.ReadLine();
                            return;
                        }
                    }
                    if (newCar.y < Console.WindowHeight)
                    {
                        newList.Add(newCar);
                    }
                    
                }
               enemyCars = newList;
                
                //Clear the console
                Console.Clear();
                //Redraw playfield


                foreach (Car car in enemyCars)
                {
                    PrintOnPosition(car.x, car.y, car.c, car.color);
                }
                if (colide==true)
                {
                    enemyCars.Clear();
                    PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Yellow);
                }
                else
                {
                    PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
                }
                colide = false;
                //Drow Info

                stringPrintOnPosition(8,5,"Lives : " + livesCount,ConsoleColor.White);
                stringPrintOnPosition(8, 6, "Speed : " + speed, ConsoleColor.White);
                //Console.Beep();
                //Slow donw the speed
                Thread.Sleep((int)(300 - speed));
            }
        }
    }
}
