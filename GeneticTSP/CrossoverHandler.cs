using System;
using System.Linq;

namespace GeneticTSP
{
    public static class CrossoverHandler
    {

        #region Public Methods

        public static Tour Crossover(Tour parent1, Tour parent2, CrossoverMethod method)
        {
            switch (method)
            {
                case CrossoverMethod.Cycle:
                    return CycleCrossover(parent1, parent2);
                case CrossoverMethod.ImprovedGreedy:
                    return ImprovedGreedyCrossover(parent1, parent2);
                default:
                    return OrderedCrossover(parent1, parent2);
            }
        }

        #endregion

        #region Private Methods

        private static Tour OrderedCrossover(Tour parent1, Tour parent2)
        {
            var child = new Tour(false);
            CryptoRandom.GetRandomMinMax(parent1.Size, out int min, out int max);

            for (int i = min; i <= max; i++)
            {
                child.SetCity(i, parent1.Cities[i]);
            }

            var leftIndexs = Enumerable.Range(0, parent1.Size).Where(i => i < min || i > max).ToList();

            for (int i = 0; i < parent2.Size; i++)
            {
                if (child.ContainsCity(parent2.Cities[i]))
                    continue;

                int index = leftIndexs[0];
                leftIndexs.RemoveAt(0);
                child.SetCity(index, parent2.Cities[i]);
            }

            return child;
        }

        private static Tour CycleCrossover(Tour parent1, Tour parent2)
        {
            var child = new Tour(false);

            var current = parent1.Cities[0];
            child.SetCity(0, current);

            while (true)
            {
                var opposite = parent2.Cities[parent1.Cities.IndexOf(current)];

                if (opposite == parent1.Cities[0])
                    break;

                current = opposite;
                int index = parent1.Cities.IndexOf(current);
                child.SetCity(index, current);
            }

            for (int i = 0; i < parent2.Size; i++)
            {
                if (child.Cities[i] != null)
                    continue;

                child.SetCity(i, parent2.Cities[i]);
            }

            return child;
        }

        private static Tour ImprovedGreedyCrossover(Tour parent1, Tour parent2)
        {

            // Initialize the parents doubly linked lists and the new child tour
            var parent1Dll = new LinkedList<City>();
            var parent2Dll = new LinkedList<City>();
            var child = new Tour(false);
            int i = 0;

            // Fill the doubly linked lists
            parent1.Cities.ForEach(parent1Dll.Add);
            parent2.Cities.ForEach(parent2Dll.Add);

            // First city
            int index = CryptoRandom.Next(0, parent1Dll.Count);
            var node1 = parent1Dll.GetAt(index);
            var node2 = parent2Dll.Find(node1.Data);
            var city = node1.Data;

            child.SetCity(i, city);
            parent1Dll.Remove(city);
            parent2Dll.Remove(city);

            LinkedListNode<City> CetClosestNeighbour(LinkedListNode<City>[] neighbors)
            {
                var closest = neighbors[0];
                var bestDistance = closest.Data.DistanceTo(city);

                for (int j = 1; j < 4; j++)
                {
                    var tempDistance = neighbors[j].Data.DistanceTo(city);

                    if (tempDistance < bestDistance)
                    {
                        closest = neighbors[j];
                        bestDistance = tempDistance;
                    }
                }

                return closest;
            }

            // Rest of the cities
            for (i = 1; i < parent1.Size; i++)
            {
                LinkedListNode<City>[] neighbors = { node1.Previous, node1.Next, node2.Previous, node2.Next };

                // Find the closest neighbor
                var closestNeighbour = CetClosestNeighbour(neighbors);
                city = closestNeighbour.Data;
                node1 = parent1Dll.Find(city);
                node2 = parent2Dll.Find(city);

                // Add it to the child tour then remove it from the doubly linked lists
                child.SetCity(i, city);
                parent1Dll.Remove(city);
                parent2Dll.Remove(city);
            }

            var parent1Fitness = parent1.GetFitness();
            var parent2Fitness = parent2.GetFitness();
            var childFitness = child.GetFitness();

            return child;
        }

        #endregion

    }
}