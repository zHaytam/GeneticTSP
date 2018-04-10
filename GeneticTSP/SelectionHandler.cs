using System;
using System.Linq;

namespace GeneticTSP
{
    public static class SelectionHandler
    {

        public static Tour Select(Population population)
        {
            switch (GASolver.Properties.SelectionMethod)
            {
                case SelectionMethod.Rank:
                    return RankSelection(population);
                case SelectionMethod.RouletteWheel:
                    return RouletteWheelSelection(population);
                default:
                    return TournamentSelection(population);
            }
        }

        private static Tour TournamentSelection(Population population)
        {
            var tempPop = new Population(GASolver.Properties.TournamentSize, false);

            for (int i = 0; i < GASolver.Properties.TournamentSize; i++)
            {
                int index = CryptoRandom.Next(population.Size);
                var tempTour = population.Tours[index];

                tempPop.Tours.Add(tempTour);
            }

            return tempPop.GetFittestTour();
        }

        private static Tour RankSelection(Population population)
        {
            const double bias = 1.5;
            int index = (int)(population.Size * (bias - Math.Sqrt(bias * bias - 4.0 * (bias - 1) * CryptoRandom.NextDouble())));
            return population.Tours[index];
        }

        private static Tour RouletteWheelSelection(Population population)
        {
            double sumFitness = population.Tours.Sum(t => t.GetFitness());
            double[] fitness = population.Tours.Select(t => t.GetFitness() / sumFitness).ToArray();

            double p = CryptoRandom.NextDouble();
            double s = 0;

            for (int i = 0; i < population.Size; i++)
            {
                s += fitness[i];
                if (p <= s) return population.Tours[i];
            }

            // This should never happen
            return population.Tours[CryptoRandom.Next(0, population.Size)];
        }

    }
}
