using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangingManGame
{
    class HangingMan
    {
        static void Main(string[] args)
        {

            char c = 'c';
            char h = 'h';
            char a = 'a';
            char m = 'm';
            char p = 'p';
            char i = 'i';
            char o = 'o';
            char n = 'n';

            char hiddenChar = '*';

            bool isCShown = false;
            bool isHShown = false;
            bool isAShown = false;
            bool isMShown = false;
            bool isPShown = false;
            bool isIShown = false;
            bool isOShown = false;
            bool isNShown = false;

            int errorsCount = 9;
            

            for (int k = 0; ; k++)
            {
                Console.Write("Enter command ");
                string command = Console.ReadLine();
                if (command == "restart")
                {
                    Console.WriteLine("Do you really want to restart?");
                    ConsoleKeyInfo key = Console.ReadKey();
                    if (key.Modifiers == ConsoleModifiers.Control  && key.Key == ConsoleKey.O)
                    {
                        isCShown = false;
                        isHShown = false;
                        isAShown = false;
                        isMShown = false;
                        isPShown = false;
                        isIShown = false;
                        isOShown = false;
                        isNShown = false;
                        errorsCount = 9;
                        Console.Clear();
                    }
                }
                
                if (command == "view")
                {
                    Console.WriteLine("Your live are {0}", errorsCount);
                }
                if (command =="guess")
                {
                    Console.Write("Enter character ");
                    char letter = char.Parse(Console.ReadLine());
                    if (letter == 'c')
                    {
                        if (!isCShown)
                        {
                            isCShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'h')
                    {
                        if (!isHShown)
                        {
                            isHShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'a')
                    {
                        if (!isAShown)
                        {
                            isAShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'm')
                    {
                        if (!isMShown)
                        {
                            isMShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'p')
                    {
                        if (!isPShown)
                        {
                            isPShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'i')
                    {
                        if (!isIShown)
                        {
                            isIShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'o')
                    {
                        if (!isOShown)
                        {
                            isOShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                    if (letter == 'n')
                    {
                        if (!isNShown)
                        {
                            isNShown = true;

                        }

                        else
                        {
                            Console.WriteLine("You already revealed this letter");
                        }
                    }
                     
                    if (letter != 'c' && letter != 'h' && letter != 'a' && letter != 'm' && letter != 'p' && letter != 'i' && letter != 'o' && letter != 'n')
                    {
                        -- errorsCount;
                        Console.WriteLine("You have {0} chances left", errorsCount);
                    }
                    if (errorsCount ==0)
                    {
                        Console.WriteLine("You lose motherfucker! Try being a stupid fuck again?");
                        isCShown = false;
                        isHShown = false;
                        isAShown = false;
                        isMShown = false;
                        isPShown = false;
                        isIShown = false;
                        isOShown = false;
                        isNShown = false;
                        errorsCount = 9;
                        Console.Clear();
                    }
                    if (isCShown)
                    {
                        Console.Write("{0}",c);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isHShown)
                    {
                        Console.Write("{0}", h);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isAShown)
                    {
                        Console.Write("{0}", a);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isMShown)
                    {
                        Console.Write("{0}", m);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isPShown)
                    {
                        Console.Write("{0}", p);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isIShown)
                    {
                        Console.Write("{0}", i);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isOShown)
                    {
                        Console.Write("{0}", o);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    if (isNShown)
                    {
                        Console.Write("{0}", n);
                    }
                    else
                    {
                        Console.Write(hiddenChar);
                    }
                    Console.WriteLine();
                    if (isCShown && isHShown && isAShown && isMShown && isPShown && isIShown && isOShown && isNShown)
                    {
                        Console.WriteLine("You win, you fucker");
                        isCShown = false;
                        isHShown = false;
                        isAShown = false;
                        isMShown = false;
                        isPShown = false;
                        isIShown = false;
                        isOShown = false;
                        isNShown = false;
                        errorsCount = 9;
                        Console.Clear();

                    }
                }
               

            }




        }
    }
}
