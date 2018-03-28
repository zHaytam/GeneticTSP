namespace GeneticTSP
{
    /// <summary>
    /// 2-Opt Algorithm based on https://en.wikipedia.org/wiki/2-opt
    /// </summary>
    public static class OptHeuristics
    {

        public static void ApplyTwoOpt(Tour tour)
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
                        int ipo = i + 1 >= tour.Size ? i + 1 - tour.Size : i + 1;
                        int jpo = j + 1 >= tour.Size ? j + 1 - tour.Size : j + 1;

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

        public static void ApplyGreedy3Opt(Tour tour)
        {
            bool modified = true;
            while (modified)
            {
                modified = false;
                double bestDistance = tour.GetDistance();

                for (int i = 1; i < tour.Size; i++)
                {
                    for (int j = i + 1; j < tour.Size; j++)
                    {
                        for (int k = j + 1; k < tour.Size; k++)
                        {
                            tour.SwapCities(i, k);
                            tour.SwapCities(j, k);
                            double tempDistance = tour.GetDistance();

                            if (tempDistance < bestDistance)
                            {
                                bestDistance = tempDistance;
                                modified = true;
                            }
                            else
                            {
                                tour.SwapCities(j, k);
                                tour.SwapCities(i, k);
                            }
                        }
                    }
                }
            }
        }

        private static void Reverse(Tour tour, int i, int j)
        {
            for (int k = 0; k < (j - i + 1) / 2; k++)
            {
                tour.SwapCities(i + k, j - k);
            }
        }

    }
}