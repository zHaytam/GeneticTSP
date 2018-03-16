namespace GeneticTSP
{
    /// <summary>
    /// 2-Opt Algorithm based on https://en.wikipedia.org/wiki/2-opt
    /// </summary>
    public static class TwoOptHeuristic
    {

        public static Tour PerformOn(Tour tour)
        {
            bool modified = true;

            while (modified)
            {
                modified = false;
                var bestDistance = tour.GetDistance();

                for (int i = 1; i < tour.Size - 1; i++)
                {
                    for (int k = i + 1; k < tour.Size; k++)
                    {
                        var newTour = TwoOptSwap(tour, i, k);
                        var tempDistance = newTour.GetDistance();

                        if (tempDistance < bestDistance)
                        {
                            tour = newTour;
                            bestDistance = tempDistance;
                            modified = true;
                        }
                    }
                }
            }

            return tour;
        }

        private static Tour TwoOptSwap(Tour tour, int i, int k)
        {
            var newTour = new Tour(false);

            // take route[0] to route[i-1] and add them in order to new_route
            for (int j = 0; j <= i - 1; j++)
            {
                newTour.SetCity(j, tour.Cities[j]);
            }

            // take route[i] to route[k] and add them in reverse order to new_route
            int d = 0;
            for (int j = i; j <= k; j++, d++)
            {
                newTour.SetCity(j, tour.Cities[k - d]);
            }

            // take route[k+1] to end and add them in order to new_route
            for (int j = k + 1; j < tour.Size; j++)
            {
                newTour.SetCity(j, tour.Cities[j]);
            }

            return newTour;

        }

        public static void Apply(Tour tour)
        {
            if (tour.Size < 4)
                return;

            bool modified = true;
            while (modified)
            {
                modified = false;

                for (int i = 0; i < tour.Size; i++)
                {
                    for (int j = i + 2; j < tour.Size; j++)
                    {
                        int ipo = i + 1 == tour.Size ? 0 : i + 1;
                        int jpo = j + 1 == tour.Size ? 0 : j + 1;

                        double d1 = tour.Cities[i].DistanceTo(tour.Cities[ipo]) + tour.Cities[j].DistanceTo(tour.Cities[jpo]);
                        double d2 = tour.Cities[i].DistanceTo(tour.Cities[j]) + tour.Cities[ipo].DistanceTo(tour.Cities[jpo]);

                        if (d2 < d1)
                        {
                            Reverse(tour, i + 1, j);
                            modified = true;
                        }
                    }
                }
            }
        }

        private static void Reverse(Tour tour, int i, int j)
        {
            for (int k = 0; k < (j - i + 1) / 2; k++)
            {
                var temp = tour.Cities[i + k];
                tour.Cities[i + k] = tour.Cities[j - k];
                tour.Cities[j - k] = temp;
            }
        }

    }
}