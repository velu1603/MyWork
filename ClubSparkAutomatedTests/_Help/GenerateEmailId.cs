using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSparkAutomatedTests._Help
{
    public static class GenerateEmailId
    {
        public static string GenerateRandomEmailId()
        {
            var randomNumber = RandomGenerator.RandomNumber(1, 5000);
            var randomString = RandomGenerator.RandomString(4, false);
            return "auto" + randomString + randomNumber + "@gmail.com";                       

            
        }

    }
}
