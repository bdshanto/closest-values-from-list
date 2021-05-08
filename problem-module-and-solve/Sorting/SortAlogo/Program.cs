using System;
using static System.Console;
namespace SortAlogo
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new[] { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48, 100, 20 };

            BubbleSortUseNestedLoop(array, out var bubbleSortUseNestedLoop);
            PrintLine("", bubbleSortUseNestedLoop);

        }

        private static void BubbleSortUseNestedLoop(int[] arr, out int[] array)
        {
            array = new int[] { };

            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1])
                    {
                        var temp = arr[sort + 1];
                        arr[sort + 1] = arr[sort];
                        arr[sort] = temp;
                    }
                }
            }

            array = arr;
            ReadKey();

        }

        private static void BubbleSort()
        {

        }

        static void PrintLine(string sortName, int[] args)
        {
            WriteLine(sortName);
            for (int i = 0; i < args?.Length; i++)
            {
                Write($"{args[i]}, ");
            }
            WriteLine("------------------------->\n");

            ReadKey();
        }


    }


}
