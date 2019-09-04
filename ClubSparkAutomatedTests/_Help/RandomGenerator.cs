using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public static class RandomGenerator
    {
        // Generate a random number between two numbers    
        public static int RandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size    
        public static string RandomString(int size, bool lowerCase)
        {
            var builder = new StringBuilder();
            var random = new Random();
            char ch;
            for (var i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password    
        public static string RandomPassword()
        {
            var builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }
    }
}
