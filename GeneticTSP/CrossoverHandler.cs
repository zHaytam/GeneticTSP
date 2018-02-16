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
                case CrossoverMethod.Ordered:
                    return OrderedCrossover(parent1, parent2);
                case CrossoverMethod.Cycle:
                    return CycleCrossover(parent1, parent2);
                default:
                    return null;
            }
        }

        #endregion

        #region Private Methods

        private static Tour OrderedCrossover(Tour parent1, Tour parent2)
        {
            var child = new Tour(false);
            CryptoRandom.GetRandomMinMax(parent1.Size, out int min, out int max);
            // Console.WriteLine("min = {0}, max = {1}, start = {2}", min, max, parent1.Cities[min]);

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

        #endregion

    }
}
