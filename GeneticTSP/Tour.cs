using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticTSP
{
    public class Tour
    {

        #region Fields

        private double? _distance;

        private double? _fitness;

        #endregion

        #region Properties

        public List<City> Cities { get; }

        public int Size => Cities.Count;

        #endregion

        public Tour(bool initialize)
        {
            Cities = initialize ? CitiesHolder.GetShuffledCopy() : Enumerable.Repeat<City>(null, CitiesHolder.Cities.Count).ToList();
        }

        #region Public Methods

        public void SetCity(int index, City city)
        {
            Cities[index] = city;

            // Clear the distance/fitness cache
            _distance = _fitness = null;
        }

        public double GetDistance()
        {
            if (_distance != null)
                return _distance.Value;

            _distance = 0;

            for (int i = 0; i < Size; i++)
            {
                int index2 = i + 1;
                if (index2 == Size) index2 = 0;

                _distance += Cities[i].DistanceTo(Cities[index2]);
            }

            return _distance.Value;
        }

        public double GetFitness()
        {
            if (_fitness != null)
                return _fitness.Value;

            _fitness = 1 / GetDistance();
            return _fitness.Value;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                sb.AppendLine(Cities[i].ToString());
            }

            return sb.ToString();
        }

        public bool ContainsCity(City city) => Cities.Contains(city);

        #endregion

    }
}