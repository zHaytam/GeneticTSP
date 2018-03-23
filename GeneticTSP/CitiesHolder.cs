using System;
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
            //Console.WriteLine(Cities.First(c => c.Id == 1).DistanceTo(Cities.First(c => c.Id == 2)));


            //var ids = new[]
            //{
            //    24, 12, 40, 39, 18, 41, 43, 36, 14, 44, 32, 38, 9, 48, 8, 29, 33, 20, 49, 15, 28, 19, 34, 35, 2, 27, 30, 25, 7, 47, 26,
            //    31, 0, 21, 1, 10, 37, 4, 11, 16, 3, 17, 46, 45, 50, 5, 22, 6, 42, 23, 13
            //};

            //var tour = new Tour(false);
            //for (int i = 0; i < ids.Length; i++)
            //{
            //    tour.SetCity(i, Cities.First(c => c.Id == ids[i] + 1));
            //}

            //Console.WriteLine(tour.GetDistance()); // 443



            //ids = new[]
            //{
            //    1,
            //    22,
            //    8,
            //    26,
            //    31,
            //    28,
            //    3,
            //    36,
            //    35,
            //    20,
            //    2,
            //    29,
            //    21,
            //    16,
            //    50,
            //    34,
            //    30,
            //    9,
            //    49,
            //    10,
            //    39,
            //    33,
            //    45,
            //    15,
            //    44,
            //    42,
            //    40,
            //    19,
            //    41,
            //    13,
            //    25,
            //    14,
            //    24,
            //    43,
            //    7,
            //    23,
            //    48,
            //    6,
            //    27,
            //    51,
            //    46,
            //    12,
            //    47,
            //    18,
            //    4,
            //    17,
            //    37,
            //    5,
            //    38,
            //    11,
            //    32,
            //};
        }

        public static List<City> GetCitiesCopy()
        {
            switch (GASolver.Properties.InitialPopulationMethod)
            {
                case InitialPopulationMethod.Greedy:
                    return GetGreedyCopy();
                case InitialPopulationMethod.GreedyNearestNeighbour:
                    return GetGreedyNearestNeighbourCopy();
                default:
                    return GetShuffledCopy();
            }
        }

        private static List<City> GetShuffledCopy()
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

        private static List<City> GetGreedyCopy()
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

        private static List<City> GetGreedyNearestNeighbourCopy()
        {
            var copy = Cities.ToList();
            var greedyList = new List<City>();

            int index = CryptoRandom.Next(0, copy.Count);
            greedyList.Add(copy[index]);
            copy.RemoveAt(index);

            int i = 0;
            var currentCity = greedyList[i];

            while (copy.Count != 0)
            {
                double bestDist = double.MaxValue;
                City bestCity = null;

                foreach (var city in copy)
                {
                    double tempDist = city.DistanceTo(currentCity);
                    if (tempDist < bestDist)
                    {
                        bestDist = tempDist;
                        bestCity = city;
                    }
                }

                i++;
                greedyList.Add(bestCity);
                copy.Remove(bestCity);
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
