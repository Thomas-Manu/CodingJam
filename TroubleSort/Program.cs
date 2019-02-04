using System;
using System.IO;
using System.Collections.Generic;

namespace TroubleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                int length = int.Parse(Console.ReadLine());
                int[] list = Array.ConvertAll(Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.None), int.Parse);
                int ableToSort = TroubleSort(length, list);
                Console.WriteLine("Case #" + (i + 1) + ": " + (ableToSort == -1 ? "OK" : ableToSort.ToString()));
            }
        }

        static int TroubleSort(int length, int[] list)
        {
            int finalAnswer = -1;
            List<int> sortedList = new List<int>();
            sortedList.AddRange(list);
            
            List<int> evenList = new List<int>();
            List<int> oddList = new List<int>();

            for (int i = 0; i < length; i++)
            {
                if (i % 2 == 0) 
                {
                    evenList.Add(list[i]);
                }
                else
                {
                    oddList.Add(list[i]);
                }
            }

            sortedList.Clear();
            evenList.Sort();
            oddList.Sort();

            // Checks to see if the list is sorted
            for (int i = 0; i < oddList.Count; i++)
            {
                if (oddList[i] < evenList[i])
                {
                    finalAnswer = i*2;
                    break;
                }
                else if (i + 1 < evenList.Count && evenList[i + 1] < oddList[i])
                {
                    finalAnswer = i*2 + 1;
                    break;
                }
            }
            return finalAnswer;
        }
    }
}
