﻿using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace GeneticTSP
{
    public class GASolver
    {

        #region Fields

        private CancellationTokenSource _cancellationTokenSource;

        #endregion

        #region Properties

        public GASolverProperties Properties { get; }

        public Population CurrentPopulation { get; private set; }

        public Tour FittestTour { get; private set; }

        public double CurrentBestDistance => CurrentPopulation?.GetFittestTour().GetDistance() ?? 0;

        public double CurrentBestFitness => CurrentPopulation?.GetFittestTour().GetFitness() ?? 0;

        #endregion

        #region Events

        public event Action Started;
        public event Action<double> Stopped;
        public event Action NewFittest;

        #endregion

        public GASolver() : this(new GASolverProperties(500, 50, 0.015, 5, true, CrossoverMethod.ImprovedGreedy)) { }

        public GASolver(GASolverProperties properties)
        {
            Properties = properties;
        }

        #region Public Methods

        public void StartSolving(IProgress<int> progress)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            Task.Factory.StartNew(() =>
            {
                // Initial population
                CurrentPopulation = new Population(Properties.PopulationsSize, true);
                FittestTour = CurrentPopulation.GetFittestTour();
                NewFittest?.Invoke();

                // Start
                Start(progress);
            },
            _cancellationTokenSource.Token);

            Started?.Invoke();
        }

        public void StopSolving() => _cancellationTokenSource?.Cancel();

        #endregion

        #region Private Methods

        private void Start(IProgress<int> progress)
        {
            var stopwatch = Stopwatch.StartNew();

            for (int i = 0; i < Properties.MaxGenerations; i++)
            {
                if (_cancellationTokenSource.IsCancellationRequested)
                    break;

                EvolvePopulation();

                var tempFittest = CurrentPopulation.GetFittestTour();
                if (tempFittest.GetFitness() > FittestTour.GetFitness())
                {
                    FittestTour = tempFittest;
                    NewFittest?.Invoke();
                }

                // Report the progress
                progress?.Report(i + 1);
            }

            Stopped?.Invoke(stopwatch.Elapsed.TotalMilliseconds);
        }

        private void EvolvePopulation()
        {
            if (CurrentPopulation == null)
                return;

            var newPop = new Population(Properties.PopulationsSize, false);
            int startingIndex = 0;

            // If elitism is true, add the fittest
            if (Properties.Elitism)
            {
                newPop.Tours.Add(CurrentPopulation.GetFittestTour());
                startingIndex++;
            }

            for (int i = startingIndex; i < Properties.PopulationsSize; i++)
            {
                // Select parents with tournament selection
                var parent1 = TournamentSelection();
                var parent2 = TournamentSelection(parent1);

                // Generate a child tour with Crossover
                var child = CrossoverHandler.Crossover(parent1, parent2, Properties.CrossoverMethod);

                // Mutate the new child
                Mutate(child);

                // Apply 2-opt-heuristic
                //child = TwoOptHeuristic.PerformOn(child);
                TwoOptHeuristic.Apply(child);

                newPop.Tours.Add(child);
            }

            CurrentPopulation = newPop;
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
                int index = CryptoRandom.Next(CurrentPopulation.Size);
                var tempTour = CurrentPopulation.Tours[index];

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