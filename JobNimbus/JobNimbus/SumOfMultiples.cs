using System;
using System.Collections.Generic;
using System.Text;

namespace JobNimbus
{
    public class SumOfMultiples
    {
        /// <summary>
        /// Calculates the sum of multiples below the targetNumber. 
        /// </summary>
        /// <param name="targetNumber">
        /// The number up to which the sum of multiples has to be calculated. 
        /// </param>
        /// <param name="multiples">
        /// multiples whose sum has to be calculated
        /// </param>
        /// <returns>
        /// The sum of the multiples below the target number
        /// </returns>
        public static long Sum(int targetNumber, int[]multiples)
        {
            if (targetNumber == 0)
            {
                return 0;
            }
            if ((multiples is null)||multiples.Length ==0)
            {
                throw new Exception("Invalid multiples list");
            }
            //This is Arithmetic Progression
            //Sum of n terms of AP is given by 
            //  N (2a + (N-1)d)
            //  --
            //  2
            //For multiples of 3-- less than 10, a = 3, d = 5, N = 3
            //

            try
            {
                long productOfMultiples = 1;
                long sum = 0;

                for (int i = 0; i < multiples.Length; i++)
                {
                    int multiple = multiples[i];
                    int numberOfMultiples = (targetNumber - 1) / multiple;
                    sum += SumOfAP(numberOfMultiples, multiple, multiple);
                    productOfMultiples *= multiple;
                }

                long numOfMultiplesOfProduct = (targetNumber - 1) / productOfMultiples;


                long sumOfMultiplesOfProduct = SumOfAP(numOfMultiplesOfProduct, productOfMultiples, productOfMultiples);

                sum = sum - sumOfMultiplesOfProduct;

                return sum;
            }
            catch (DivideByZeroException)
            {
                throw new Exception("Multiple contains 0.");
            }
            catch (Exception)
            {
                //Log the Exception
                throw; 
            }
        }

        private static long SumOfAP(long n, long a, long d)
        {
            return n * ((2 * a) + (n - 1) * d) / 2;
        }
    }
}
