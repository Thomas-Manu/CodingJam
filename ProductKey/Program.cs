using System;
using System.Text;

namespace WaffleChoppers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                string stuff = Console.ReadLine();
                int stu = int.Parse(Console.ReadLine());
                Console.WriteLine("Bleh " + solution(stuff, stu));
            }
        }
    
        static string solution(string S, int K) {
            StringBuilder finalString = new StringBuilder();
            finalString.Append(S.Replace("-", ""));
            int countFirst = finalString.Length % K;
            int count = 0;
            finalString.Insert(countFirst, "-");
            Console.WriteLine("1 " + finalString.Length);
            for (int i = countFirst + 1 + K; i < finalString.Length; i+=K+1)
            {
                finalString.Insert(i, "-");
                Console.WriteLine("2 " + finalString.Length);
                Console.WriteLine("I value " + i);
            }
            return finalString.ToString();
        }
    }
}
