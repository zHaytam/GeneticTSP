namespace GeneticTSP
{
    public static class MutationHandler
    {

        #region Public Methods

        public static void Mutate(Tour tour)
        {
            switch (GASolver.Properties.MutationMethod)
            {
                case MutationMethod.ReverseSequence:
                    ReverseSequenceMutation(tour);
                    break;
                default:
                    PartialShuffleMutation(tour);
                    break;
            }
        }

        #endregion

        #region Private Methods

        private static void PartialShuffleMutation(Tour tour)
        {
            for (int i = 0; i < tour.Size; i++)
            {
                if (CryptoRandom.NextDouble() >= GASolver.Properties.MutationRate)
                    continue;

                int index = CryptoRandom.Next(tour.Size);
                tour.SwapCities(i, index);
            }
        }

        private static void ReverseSequenceMutation(Tour tour)
        {
            if (CryptoRandom.NextDouble() >= GASolver.Properties.MutationRate)
                return;

            CryptoRandom.GetRandomMinMax(tour.Size, out int a, out int b);

            do
            {
                tour.SwapCities(a, b);
                a++;
                b--;
            }
            while (a < b);
        }

        #endregion

    }
}
