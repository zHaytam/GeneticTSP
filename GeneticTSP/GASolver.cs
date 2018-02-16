namespace GeneticTSP
{
    public class GASolver
    {

        #region Fields

        private Population _currentPopulation;

        #endregion

        #region Properties

        public GASolverProperties Properties { get; }

        public double BestDistance => _currentPopulation?.GetFittestTour().GetDistance() ?? 0;

        public double BestFitness => _currentPopulation?.GetFittestTour().GetFitness() ?? 0;

        #endregion

        public GASolver() : this(new GASolverProperties(10, 50, 0.02, 5, true, CrossoverMethod.Ordered)) { }

        public GASolver(GASolverProperties properties)
        {
            Properties = properties;
            _currentPopulation = new Population(Properties.PopulationsSize, true);
        }

        #region Public Methods

        public GASolverResult Solve()
        {
            var fittestTour = _currentPopulation.GetFittestTour();

            for (int i = 0; i < Properties.MaxGenerations; i++)
            {
                EvolvePopulation();

                var tempFittest = _currentPopulation.GetFittestTour();
                if (tempFittest.GetFitness() > fittestTour.GetFitness())
                {
                    fittestTour = tempFittest;
                }
            }

            return new GASolverResult(_currentPopulation, fittestTour);
        }

        #endregion

        #region Private Methods

        private void EvolvePopulation()
        {
            if (_currentPopulation == null)
                return;

            var newPop = new Population(Properties.PopulationsSize, false);
            int startingIndex = 0;

            // If elitism is true, add the fittest
            if (Properties.Elitism)
            {
                newPop.Tours.Add(_currentPopulation.GetFittestTour());
                startingIndex++;
            }

            for (int i = startingIndex; i < Properties.PopulationsSize; i++)
            {
                // Select parents with tournament selection
                var parent1 = TournamentSelection();
                var parent2 = TournamentSelection(parent1);

                // Generate a child tour with Crossover
                var child = CrossoverHandler.Crossover(parent1, parent2, Properties.CrossoverMethod);
                // Console.WriteLine("Distance of new child tour: {0}", child.GetDistance());

                // Mutate the new child before adding it to the new population
                Mutate(child);
                newPop.Tours.Add(child);
            }

            _currentPopulation = newPop;
        }

        private void Mutate(Tour tour)
        {
            for (int i = 0; i < tour.Size; i++)
            {
                if (CryptoRandom.NextDouble() >= Properties.MutationRate)
                    continue;

                int index = CryptoRandom.Next(tour.Size);
                var temp = tour.Cities[i];
                tour.SetCity(i, tour.Cities[index]);
                tour.SetCity(index, temp);
            }
        }

        private Tour TournamentSelection(Tour tourToExclude = null)
        {
            var tempPop = new Population(Properties.TournamentSize, false);

            for (int i = 0; i < Properties.TournamentSize; i++)
            {
                int index = CryptoRandom.Next(_currentPopulation.Size);
                var tempTour = _currentPopulation.Tours[index];

                // In case we found the tour we wanted to tourToExclude
                if (tourToExclude != null && tempTour == tourToExclude)
                {
                    i--;
                    continue;
                }

                tempPop.Tours.Add(tempTour);
            }

            return tempPop.GetFittestTour();
        }

        #endregion

    }
}