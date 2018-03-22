using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using TspLibNet;

namespace GeneticTSP
{
    public partial class MultiSolver : Form
    {

        private readonly object _lockObject = new object();
        private readonly int _runs;
        private int _started;
        private int _finished;
        private readonly Dictionary<GASolver, double> _solvers;


        public int Started
        {
            get => _started;
            set
            {
                lock (_lockObject)
                {
                    _started = value;
                    BeginInvoke((Action)(() =>
                   {
                       pbStarted.Value = _started;
                       lblStarted.Text = $"{_started} / {_runs} started";
                   }));
                }
            }
        }

        public int Finished
        {
            get => _finished;
            set
            {
                lock (_lockObject)
                {
                    _finished = value;
                    BeginInvoke((Action)(() =>
                   {
                       pbFinished.Value = _finished;
                       lblFinished.Text = $"{_finished} / {_runs} finished";
                   }));
                }
            }
        }


        public MultiSolver(GASolverProperties properties, int runs, TspLib95Item item)
        {
            InitializeComponent();

            _runs = runs;
            _solvers = new Dictionary<GASolver, double>();
            pbFinished.Maximum = pbStarted.Maximum = _runs;
            lblTitle.Text = string.Format(lblTitle.Text, _runs, item.Problem.Name);
            lblFinished.Text = $"{_finished} / {_runs} finished";

            var pts1 = new ChartValues<ObservablePoint>();
            var pts2 = new ChartValues<ObservablePoint>();
            chartDistances.Series.Add(new LineSeries
            {
                Title = "Found",
                Values = pts1
            });
            chartDistances.Series.Add(new LineSeries
            {
                Title = "Optimal",
                Values = pts2
            });

            for (int i = 0; i < _runs; i++)
            {
                var solver = new GASolver(properties);
                solver.Started += () => Started++;
                solver.Stopped += timeElapsed =>
                {
                    _solvers[solver] = timeElapsed;
                    Finished++;

                    BeginInvoke((Action)(() =>
                    {
                        pts1.Add(new ObservablePoint(Finished, solver.FittestTour.GetDistance()));
                        pts2.Add(new ObservablePoint(Finished, item.OptimalTourDistance));
                    }));
                };

                _solvers.Add(solver, 0);
            }
        }

        private void MultiSolver_Shown(object sender, EventArgs e)
        {
            _solvers.Keys.ToList().ForEach(solver => solver.StartSolving(null));
        }

    }
}
