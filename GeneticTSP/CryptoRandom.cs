using System;
using System.Security.Cryptography;

namespace GeneticTSP
{
    ///<summary>
    /// Represents a pseudo-random number generator, a device that produces random data.
    /// Inspired from: http://eimagine.com/how-to-generate-better-random-numbers-in-c-net-2/
    ///</summary>
    public class CryptoRandom
    {

        private static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        /// <summary>
        ///  Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        /// <param name="buffer">An array of bytes to contain random numbers.</param>
        public static void GetBytes(byte[] buffer)
        {
            Rng.GetBytes(buffer);
        }

        ///<summary>
        /// Returns a random number between 0.0 and 1.0.
        ///</summary>
        public static double NextDouble()
        {
            byte[] b = new byte[4];
            Rng.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        ///<summary>
        /// Returns a random number within the specified range.
        ///</summary>
        ///<param name="minValue">The inclusive lower bound of the random number returned.</param>
        ///<param name="maxValue">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue.</param>
        public static int Next(int minValue, int maxValue)
        {
            return (int)Math.Round(NextDouble() * (maxValue - minValue - 1)) + minValue;
        }

        ///<summary>
        /// Returns a nonnegative random number.
        ///</summary>
        public static int Next()
        {
            return Next(0, int.MaxValue);
        }

        ///<summary>
        /// Returns a nonnegative random number less than the specified maximum
        ///</summary>
        ///<param name="maxValue">The inclusive upper bound of the random number returned. maxValue must be greater than or equal 0</param>
        public static int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

    }
}
