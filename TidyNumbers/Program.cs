using System;
using System.IO;

namespace TidyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader file = new StreamReader("B-small-practice.in");
            string fileContents = file.ReadToEnd;
            file.Close();

            StringReader reader = new StringReader(fileContents);
            int numberOfTestCases = reader.ReadLine();
            
        }
    }
}
