namespace GeneticTSP
{
    public class GASolverResult
    {

        #region Properties

        public Population LastPopulation { get; }

        public Tour FittestTour { get; }

        #endregion

        public GASolverResult(Population lastPopulation, Tour fittestTour)
        {
            LastPopulation = lastPopulation;
            FittestTour = fittestTour;
        }

    }
}
