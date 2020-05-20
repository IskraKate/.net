using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace CharChainsAreFallingProj
{
    public class MyThread1
    {
        public Random rnd;
        public Point point;
        int count;
        List<char> chrArray;
        List<string> consoleArray;
        int oldCount;

        public MyThread1()
        {
            rnd = new Random();

            count = rnd.Next(5, 10);
            
            point.X = rnd.Next(Console.WindowLeft, Console.WindowLeft + Console.WindowWidth);
            point.Y = 0;

        }

        public void CheckNull(object locker)
        {
            for (int i = 0; i < Console.WindowHeight - 1; i++)
            {
                lock(locker)
                {
                    Console.SetCursorPosition(0, i);
                    consoleArray.Add(Console.ReadLine());
                }

            }

            for (int i = 0; i < consoleArray.Count; i++)
            {
                if (consoleArray[i].ElementAt(point.X) != ' ')
                {
                    point.X = rnd.Next(Console.WindowLeft, Console.WindowLeft + Console.WindowWidth);
                    point.Y = 0;

                    CheckNull(locker);
                }
            }
        }

        public void Run(object locker)
        {
 
            chrArray = new List<char>();

            for (int i = 0; i < count; i++)
            {
                chrArray.Add(Char.ToUpper((char)rnd.Next(97, 122)));
            }

            for (int h = 0; h < Console.WindowHeight - 1 + count; h++)
            {
                if (h < count)
                {
                    for (int i = 0; i < h; i++)
                    {
                        lock (locker)
                        {
                            if (i == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (i == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }

                            Console.SetCursorPosition(point.X, point.Y + h - i);
                            chrArray[i] = Char.ToUpper((char)rnd.Next(97, 122));
                            Console.WriteLine(chrArray[i]);
                        }
                    }
                    Thread.Sleep(100);
                }
                else if (h < Console.WindowHeight - 1)
                {
                    for (int i = 0; i < count; i++)
                    {
                        lock (locker)
                        {
                            if (i == 0)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                            else if (i == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }

                            Console.SetCursorPosition(point.X, point.Y + h - i);
                            chrArray[i] = Char.ToUpper((char)rnd.Next(97, 122));
                            Console.WriteLine(chrArray[i]);

                            Console.SetCursorPosition(point.X, point.Y + h - count);
                            Console.WriteLine(' ');

                        }
                    }
                    Thread.Sleep(100);
                }
                else
                {
                    oldCount = count;

                    for (int i = 0; i < oldCount; i++)
                    {
                        lock (locker)
                        {
                            for (int k = 1; k < count; k++)
                            { 
                                if (k > 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                } 

                                Console.SetCursorPosition(point.X, point.Y + h - k);
                                chrArray[k] = Char.ToUpper((char)rnd.Next(97, 122));
                                Console.WriteLine(chrArray[k]);
                            }

                            Console.SetCursorPosition(point.X, point.Y + h - count);
                            Console.WriteLine(' ');

                            chrArray.RemoveAt(0);
                            count--;
                        }

                        Thread.Sleep(100);
                    }
                }
            }

            count = oldCount;

            Run(locker);
        }

    }


    class Program
    {
        static object locker = new object();

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

            for (int i = 0; i < 15; i++)
            {
                var foregroundThread = new Thread(new ParameterizedThreadStart(new MyThread1().Run));
                foregroundThread.Start(locker);
            }

            Console.ReadKey();
        }

    }
}
