using System;
using TspLibNet.Graph.Nodes;

namespace GeneticTSP
{
    public class City
    {

        #region Properties

        public double X { get; }

        public double Y { get; }

        #endregion

        public City(Node2D node)
        {
            X = node.X;
            Y = node.Y;
        }

        #region Public Methods

        public double DistanceTo(City city)
        {
            return Math.Sqrt(Math.Pow(city.X - X, 2) + Math.Pow(city.Y - Y, 2));
        }

        public override string ToString() => $"({X}, {Y})";

        #endregion

    }
}