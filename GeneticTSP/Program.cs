using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneticTSP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //City city = new City(60, 200);
            //CitiesHolder.Cities.Add(city);
            //City city2 = new City(180, 200);
            //CitiesHolder.Cities.Add(city2);
            //City city3 = new City(80, 180);
            //CitiesHolder.Cities.Add(city3);
            //City city4 = new City(140, 180);
            //CitiesHolder.Cities.Add(city4);
            //City city5 = new City(20, 160);
            //CitiesHolder.Cities.Add(city5);
            //City city6 = new City(100, 160);
            //CitiesHolder.Cities.Add(city6);
            //City city7 = new City(200, 160);
            //CitiesHolder.Cities.Add(city7);
            //City city8 = new City(140, 140);
            //CitiesHolder.Cities.Add(city8);
            //City city9 = new City(40, 120);
            //CitiesHolder.Cities.Add(city9);
            //City city10 = new City(100, 120);
            //CitiesHolder.Cities.Add(city10);
            //City city11 = new City(180, 100);
            //CitiesHolder.Cities.Add(city11);
            //City city12 = new City(60, 80);
            //CitiesHolder.Cities.Add(city12);
            //City city13 = new City(120, 80);
            //CitiesHolder.Cities.Add(city13);
            //City city14 = new City(180, 60);
            //CitiesHolder.Cities.Add(city14);
            //City city15 = new City(20, 40);
            //CitiesHolder.Cities.Add(city15);
            //City city16 = new City(100, 40);
            //CitiesHolder.Cities.Add(city16);
            //City city17 = new City(200, 40);
            //CitiesHolder.Cities.Add(city17);
            //City city18 = new City(20, 20);
            //CitiesHolder.Cities.Add(city18);
            //City city19 = new City(60, 20);
            //CitiesHolder.Cities.Add(city19);
            //City city20 = new City(160, 20);
            //CitiesHolder.Cities.Add(city20);

            //List<double> results = new List<double>();

            //Parallel.For(0, 1000, i =>
            //{
            //    var solver = new GASolver(new GASolverProperties(
            //        100,
            //        50,
            //        0.015,
            //        5,
            //        true,
            //        CrossoverMethod.Ordered));

            //    //Console.WriteLine("Initial distance: " + solver.BestDistance);
            //    //var result = solver.Solve();
            //    //Console.WriteLine("Final distance: " + solver.BestDistance + ", Final fitness: " + solver.BestFitness);
            //    results.Add(solver.Solve().FittestTour.GetDistance());
            //});

            //Console.WriteLine("min = {0}, max = {1}, avg = {2}", results.Min(), results.Max(), results.Average());
        }
    }
}
