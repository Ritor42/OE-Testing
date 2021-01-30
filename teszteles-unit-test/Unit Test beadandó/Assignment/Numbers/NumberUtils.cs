using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Numbers
{
    public class NumberUtils
    {
        /// <summary>
        /// Gets all divisors for the number passed in.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Retuns a list of all the divisors for the number passed in.</returns>
        public List<int> GetDivisors(int number)
        {
            var divisors = new List<int>();
            var sqrt = (int)Math.Sqrt(number);
            // for (int i = 2; i <= sqrt; i++)
            for (int i = 1; i <= sqrt; i++)
            {
                if(number % i == 0)
                {
                    divisors.Add(i);
                    divisors.Add(number / i);
                }
            }

            return divisors;
        }

        /// <summary>
        /// Checks if the number passed in is a prime number or not.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>True if the number is prime, False if it is not a prime number.</returns>
        public bool IsPrime(int number)
        {
            // return number < 0 
            return number < 2 
				? false
				: GetDivisors(number).Count() == 2;
        }

        /// <summary>
        /// Checks if the number passed in is even or odd.
        /// </summary>
        /// <param name="number"></param>
        /// <returns>"even" if the number is even, "odd" in case of odd numbers.</returns>
        public string EvenOrOdd(int number)
        {
            // return number % 2 == 1
            return number % 2 == 0
				? "even"
				: "odd";
        }
    }
}