using System;

namespace SavingTheUniverse
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfTestCases = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTestCases; i++)
            {
                string[] line = Console.ReadLine().Split(new string[] {" "}, StringSplitOptions.None);
                int minNumberOfHacks = CountNumberOfHacks(int.Parse(line[0]), line[1]);
                Console.WriteLine("Case #" + (i + 1) + ": " + (minNumberOfHacks == -1 ? "IMPOSSIBLE" : minNumberOfHacks.ToString()));
            }
        }

        static int CountNumberOfHacks(int health, string program) 
        {
            int outputDamage = 0;
            int numberOfHacks = 0;
            string switchedProgram = program;

            int numberOfShots = program.Length - program.Replace("S", "").Length;
            if (numberOfShots > health) {
                 return -1;
            }
            outputDamage = DamageDone(switchedProgram);

            while (outputDamage > health) 
            {
                int firstCIndex = switchedProgram.LastIndexOf("CS");
                switchedProgram = switchedProgram.Remove(firstCIndex, 2).Insert(firstCIndex, "SC");
                outputDamage = DamageDone(switchedProgram);

                numberOfHacks++;
            }
            
            return numberOfHacks;
        }

        static int DamageDone(string program)
        {
            int totalDamage = 0;
            int damageMultiplier = 1;
            foreach (var character in program.ToCharArray()) 
            {
                if (character == 'S')
                {
                    totalDamage += damageMultiplier;
                }
                else if (character == 'C')
                {
                    damageMultiplier *= 2;
                }
            }
            return totalDamage;
        }
    }
}
