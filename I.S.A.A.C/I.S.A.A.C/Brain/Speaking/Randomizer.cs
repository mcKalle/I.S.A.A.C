using System;
using System.Collections.Generic;

namespace ISAAC.Brain.Speaking
{
    class Randomizer
    {
        private static Random random = new Random();

        public static string RandomizeAnswer(List<string> answersIn)
        {
            int index = random.Next(0, answersIn.Count);

            return answersIn[index];
        }
    }
}
