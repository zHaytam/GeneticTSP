using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticTSP
{
    public class GASolver
    {

        #region Fields

        private Population _currentPopulation;

        #endregion

        #region Properties

        public GASolverProperties Properties { get; }

        #endregion

        public GASolver() : this(new GASolverProperties(100, 50, 0.02, 5, true)) { }

        public GASolver(GASolverProperties properties)
        {
            Properties = properties;
            _currentPopulation = new Population(Properties.PopulationsSize, true);
        }

        #region Public Methods

        public void Solve()
        {
            for (int i = 0; i < Properties.MaxGenerations; i++)
            {
                EvolvePopulation();
            }
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
                var child = Crossover(parent1, parent2);

                // Mutate the new child before adding it to the new population
                Mutate(child);
                newPop.Tours.Add(child);
            }

            _currentPopulation = newPop;
        }

        private Tour Crossover(Tour parent1, Tour parent2)
        {
            var child = new Tour(false);

            // Choose a random subset from parent1
            CryptoRandom.GetRandomMinMax(parent1.Size, out int min, out int max);

            Console.WriteLine(min + " , " + max);

            // Add it to the new child tour
            for (int i = min; i < max; i++)
            {
                
            }

            return null;
        }

        private void Mutate(Tour tour)
        {
            
        }

        private Tour TournamentSelection(Tour tourToExclude = null)
        {
            var tempPop = new Population(Properties.TournamentSize, false);

            for (int i = 0; i < tempPop.Size; i++)
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