using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneticTSP
{
    public class Tour
    {

        #region Fields

        private readonly HashSet<int> _ids;

        private double? _distance;

        private double? _fitness;

        #endregion

        #region Properties

        public List<City> Cities { get; }

        public int Size => Cities.Count;

        #endregion

        public Tour(bool initialize)
        {
            _ids = new HashSet<int>();

            if (initialize)
            {
                Cities = CitiesHolder.GetCitiesCopy();
                Cities.ForEach(c => _ids.Add(c.Id));
            }
            else
            {
                Cities = Enumerable.Repeat<City>(null, CitiesHolder.Cities.Count).ToList();
            }
        }

        #region Public Methods

        public void SetCity(int index, City city)
        {
            var oldCity = Cities[index];
            if (oldCity != null)
                _ids.Remove(oldCity.Id);

            Cities[index] = city;
            _ids.Add(city.Id);

            // Clear the distance/fitness cache
            _distance = _fitness = null;
        }

        public void SwapCities(int index1, int index2)
        {
            var temp = Cities[index1];
            Cities[index1] = Cities[index2];
            Cities[index2] = temp;

            // Clear the distance/fitness cache
            _distance = _fitness = null;
        }

        public bool ContainsCity(City city) => _ids.Contains(city.Id);

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

        #endregion

    }
}