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
                n--;
                int i = CryptoRandom.Next(n + 1);
                var temp = shuffledList[i];
                shuffledList[i] = shuffledList[n];
                shuffledList[n] = temp;
            }

            return shuffledList;
        }

        public static List<City> GetGreedyCopy()
        {
            var copy = Cities.ToList();
            int ri = (int)(copy.Count * GASolver.Properties.GreedyInitialPopulationRate);
            var greedyList = new List<City>();

            for (int i = 0; i < ri; i++)
            {
                int index = CryptoRandom.Next(0, copy.Count);
                greedyList.Add(copy[index]);
                copy.RemoveAt(index);
            }

            while (copy.Count != 0)
            {
                int index = CryptoRandom.Next(0, copy.Count);

                int c = greedyList.Count;
                double bestDist = double.MaxValue;
                int bestIndex = -1;

                for (int i = 0; i <= c; i++)
                {
                    greedyList.Insert(i, copy[index]);

                    var dist = CalculateDistance(greedyList);
                    if (dist < bestDist)
                    {
                        bestDist = dist;
                        bestIndex = i;
                    }

                    greedyList.RemoveAt(i);
                }

                greedyList.Insert(bestIndex, copy[index]);
                copy.RemoveAt(index);
            }

            return greedyList;
        }

        public static double CalculateDistance(List<City> cities)
        {
            double distance = 0;

            for (int i = 0; i < cities.Count; i++)
            {
                int index2 = i + 1;
                if (index2 == cities.Count) index2 = 0;

                distance += cities[i].DistanceTo(cities[index2]);
            }

            return distance;
        }

        #endregion

    }
}
