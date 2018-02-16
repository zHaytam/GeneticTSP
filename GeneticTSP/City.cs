using System;
using TspLibNet.Graph.Nodes;

namespace GeneticTSP
{
    public class City
    {

        #region Properties

        public int Id { get; }

        public double X { get; }

        public double Y { get; }

        #endregion

        public City(Node2D node)
        {
            Id = node.Id;
            X = node.X;
            Y = node.Y;
        }

        public City(double x, double y)
        {
            X = x;
            Y = y;
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