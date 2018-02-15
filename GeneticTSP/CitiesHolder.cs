using System.Collections.Generic;
using System.Linq;
using TspLibNet.Graph.Nodes;

namespace GeneticTSP
{
    public static class CitiesHolder
    {

        #region Properties

        public static List<City> Cities { get; } = new List<City>();

        #endregion

        #region Static Methods

        public static void SetCities(NodeListBasedNodeProvider provider)
        {
            Cities.Clear();
            Cities.AddRange(provider.GetNodes().Select(node => new City(node as Node2D)));
        }

        public static List<City> GetShuffledCopy()
        {
            var shuffledList = Cities.ToList();
            int n = shuffledList.Count;

            while (n > 1)
            {
                int i = CryptoRandom.Next(n + 1);
                var temp = shuffledList[i];
                shuffledList[i] = shuffledList[n];
                shuffledList[n] = temp;
                n--;
            }

            return shuffledList;
        }

        #endregion

    }
}
