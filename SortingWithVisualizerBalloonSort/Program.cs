using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace SortingWithVisualizerBalloonSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] visualizerSize = { 29, 120 }; // rows and columns of console

            Random rnd = new Random();
            int[] arr = new int[visualizerSize[1]];
            int temp = 0;

            for (int x = 0; x < arr.Length; x++)
                arr[x] = rnd.Next(visualizerSize[0]) + 1;

            // this line just sets the window size to always display in a 
            // 120 * 30 characters in size
            Console.SetWindowSize(visualizerSize[1], visualizerSize[0] + 1);

            #region Visualizing initial display
            for (int a = visualizerSize[0]; a > 0; a--) // dictate number of rows
            {
                for (int b = 0; b < arr.Length; b++) // dictate number of columns
                {
                    if (arr[b] >= a)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
            }
            Console.Write("To be sorted using Balloon sort... Press any key to begin...");
            Console.ReadKey();
            //Console.Clear(); 
            #endregion

            for (int x = 0; x < arr.Length - 1; x++)
            {
                for (int y = x + 1; y < arr.Length; y++)
                {

                    #region Visualizing Column Selection
                    for (int a = visualizerSize[0]; a > 0; a--)
                    {
                        for (int b = x; b < y + 1; b++)
                        {
                            if (b == x || b == y)
                            {
                                Console.SetCursorPosition(b, a - 1);
                                if (b == x)
                                    Console.ForegroundColor = ConsoleColor.Red;
                                else if (b == y)
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                else
                                    Console.ResetColor();

                                if (arr[b] > visualizerSize[0] - a)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Thinking. . .                                               ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(200);
                    //Console.Clear(); 
                    #endregion

                    if (arr[x] > arr[y])
                    {
                        temp = arr[x];
                        arr[x] = arr[y];
                        arr[y] = temp;

                        #region Visualizing Swap logic
                        for (int a = visualizerSize[0]; a > 0; a--)
                        {
                            for (int b = x; b <= y; b++)
                            {
                                // by targetting specific rows
                                // we are able to cut down on processing time
                                if (b == x || b == y)
                                {
                                    Console.SetCursorPosition(b, a - 1);
                                    if (b == x || b == y)
                                        Console.ForegroundColor = ConsoleColor.Green;
                                    else
                                        Console.ResetColor();

                                    if (arr[b] > visualizerSize[0] - a)
                                        Console.Write("*");
                                    else
                                        Console.Write(" ");
                                }
                            }
                        }
                        Console.SetCursorPosition(0, 29);
                        Console.Write("Pass {0} : Swapping . . .                                             ", x);
                        //Console.ReadKey();
                        //Thread.Sleep(100);
                        //Console.Clear();
                        #endregion
                    }

                    #region Reset color
                    for (int a = visualizerSize[0]; a > 0; a--) 
                    {
                        for (int b = x; b <= y; b++) 
                        {
                            if (b == x || b == y)
                            {
                                Console.SetCursorPosition(b, a - 1);
                                Console.ResetColor();

                                if (arr[b] > visualizerSize[0] - a)
                                    Console.Write("*");
                                else
                                    Console.Write(" ");
                            }
                        }
                    }
                    Console.SetCursorPosition(0, 29);
                    Console.Write("Pass {0} : Resetting. . .                                             ", x);
                    //Console.ReadKey();
                    //Thread.Sleep(100);
                    //Console.Clear(); 
                    #endregion
                }
            }

            Console.SetCursorPosition(0, 29);
            Console.Write("Done!!!!!!!!!                                              ");
            Console.ReadKey();
        }
    }
}
