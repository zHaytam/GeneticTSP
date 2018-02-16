using System.Collections.Generic;

namespace GeneticTSP
{
    public class Population
    {

        #region Properties

        public List<Tour> Tours { get; }

        public int Size => Tours.Count == 0 ? Tours.Capacity : Tours.Count;

        #endregion

        public Population(int populationSize, bool initialize)
        {
            Tours = new List<Tour>(populationSize);

            if (!initialize)
                return;

            for (int i = 0; i < populationSize; i++)
            {
                Tours.Add(new Tour(true));
            }
        }

        #region Public Methods

        public Tour GetFittestTour()
        {
            var fittestTour = Tours[0];

            for (int i = 1; i < Size; i++)
            {
                if (Tours[i].GetFitness() > fittestTour.GetFitness())
                {
                    fittestTour = Tours[i];
                }
            }

            return fittestTour;
        }

        #endregion

    }
}
