using System;
using static System.Console;
namespace SortAlogo
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new[] { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48, 100, 20 };

            BubbleSortUseNestedLoop(array);
            PrintLine("Bubble Sort Use Nested Loop", array);

        }

        private static void BubbleSortUseNestedLoop(int[] arr)
        {
            for (int write = 0; write < arr.Length; write++)
            {
                for (int sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] > arr[sort + 1]) Swapping(arr, write, sort);
                }
            }

        }

        static void Swapping(int[] arr, int first, int next)
        {
            var temp = arr[first];
            arr[first] = arr[next];
            arr[first] = temp;

        }
        
        static void PrintLine(string sortName, params int[] args)
        {
            WriteLine(sortName + "\n");
            for (int i = 0; i < args?.Length; i++)
            {
                Write($"{args[i]}, ");
            }
            WriteLine("\n------------------------->\n");

            ReadKey();
        }


    }


}
