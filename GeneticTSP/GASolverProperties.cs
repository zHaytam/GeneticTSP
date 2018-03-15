namespace GeneticTSP
{
    public class GASolverProperties
    {

        #region Properties

        public int MaxGenerations { get; set; }

        public int PopulationsSize { get; set; }

        public double MutationRate { get; set; }

        public int TournamentSize { get; set; }

        public bool Elitism { get; set; }

        public CrossoverMethod CrossoverMethod { get; set; }

        #endregion

        public GASolverProperties(int maxGenerations, int populationsSize, double mutationRate, int tournamentSize, bool elitism, CrossoverMethod crossoverMethod)
        {
            MaxGenerations = maxGenerations;
            PopulationsSize = populationsSize;
            MutationRate = mutationRate;
            TournamentSize = tournamentSize;
            Elitism = elitism;
            CrossoverMethod = crossoverMethod;
        }

    }

    public enum CrossoverMethod
    {
        Ordered,
        Cycle,
        ImprovedGreedy
    }
}
