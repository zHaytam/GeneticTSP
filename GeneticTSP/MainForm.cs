using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TspLibNet;
using TspLibNet.DistanceFunctions;
using TspLibNet.Graph.EdgeWeights;
using TspLibNet.Graph.Nodes;

namespace GeneticTSP
{
    public partial class MainForm : Form
    {

        #region Fields

        private List<TspLib95Item> _tspItems;
        private TspLib95Item _currentItem;
        private double _widthOffset;
        private double _heightOffset;
        private float _zoomX;
        private float _zoomY;
        private readonly GASolver _gaSolver;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            _gaSolver = new GASolver();

            _gaSolver.Started += () =>
            {
                TsmiSelectProblem.Enabled = false;
                TsmiStartSolving.Enabled = false;
                TsmiStopSolving.Enabled = true;
            };

            _gaSolver.Stopped += elapsed => BeginInvoke((Action)(() =>
            {
                TsmiSelectProblem.Enabled = true;
                TsmiStartSolving.Enabled = true;
                TsmiStopSolving.Enabled = false;
                GC.Collect();

                var result = MessageBox.Show(GenerateSummary(elapsed), "Finished solving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                    return;

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Text file (.txt) | *.txt";
                    sfd.FileName = $"{_currentItem.Problem.Name}_{DateTime.Now:dd-MM-yyyy_HH-mm-ss}";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(sfd.FileName, GenerateResults(elapsed));
                    }
                }
            }));

            _gaSolver.NewFittest += () => BeginInvoke((Action)(() =>
            {
                TsslBestDistance.Text = $"Best distance so far: {_gaSolver.CurrentBestDistance}";
                TsslBestFitness.Text = $"Best fitness so far: {_gaSolver.CurrentBestFitness}";
                Invalidate();
            }));

            Resize += (s, e) => SetDimensions();
        }

        #region UI Events

        private void TsmiLoadProblems_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.SelectedPath = "D:\\Learning\\GeneticTSP\\TSPLIB95";

                if (fbd.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    TsmiSelectProblem.Enabled = false;

                    var tspLib = new TspLib95(fbd.SelectedPath);
                    _tspItems = tspLib.LoadAllTSP().ToList();

                    // In case no problems were found
                    if (_tspItems.Count == 0)
                        throw new Exception();

                    // Add the problems to the "Select a problem" menu item
                    TsmiSelectProblem.DropDownItems.Clear();

                    foreach (var item in _tspItems)
                    {
                        if (!(item.Problem.EdgeWeightsProvider is FunctionBasedWeightProvider))
                            continue;

                        var newMenuItem = new ToolStripMenuItem
                        {
                            Text = item.Problem.Name,
                            Tag = item
                        };

                        newMenuItem.Click += SelectProblem_Click;
                        TsmiSelectProblem.DropDownItems.Add(newMenuItem);
                    }

                    TsmiSelectProblem.Enabled = true;
                    TsmiLoadProblems.Enabled = false;
                    TsmiLoadProblems.Text = $"{_tspItems.Count} Problems loaded";
                }
                catch
                {
                    MessageBox.Show("An error occured.\nDid you select the right folder?", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SelectProblem_Click(object sender, EventArgs e)
        {
            _currentItem = (sender as ToolStripMenuItem)?.Tag as TspLib95Item;
            var nodesProvider = _currentItem?.Problem.NodeProvider as NodeListBasedNodeProvider;
            CitiesHolder.SetCities(nodesProvider);
            TsmiStartSolving.Enabled = true;
            TsmiSelectProblem.Text = $"Current problem: {_currentItem?.Problem.Name} ({CitiesHolder.Cities.Count} cities)";
            SetDimensions();
        }

        private void TsmiStartSolving_Click(object sender, EventArgs e)
        {
            _gaSolver.StartSolving(new Progress<int>(p =>
            {
                TspbGeneration.Value = p;
                TsslGeneration.Text = $"Generation {p} of {_gaSolver.Properties.MaxGenerations}";
            }));
        }

        private void TsmiStopSolving_Click(object sender, EventArgs e)
        {
            _gaSolver.StopSolving();
        }

        private void TsmiProperties_Click(object sender, EventArgs e)
        {
            var tempForm = new Form
            {
                Text = "GA Properties",
                Size = new Size(400, 400),
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                Icon = Icon
            };

            var propertyGrid = new PropertyGrid
            {
                Dock = DockStyle.Fill,
                SelectedObject = _gaSolver.Properties
            };

            tempForm.Controls.Add(propertyGrid);
            tempForm.ShowDialog();
            TspbGeneration.Maximum = _gaSolver.Properties.MaxGenerations;
        }

        #endregion

        #region Private Methods

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Black);

            if (_gaSolver.FittestTour == null)
                return;

            DrawTour(_gaSolver.FittestTour, e.Graphics);
        }

        private void DrawTour(Tour tour, Graphics g)
        {
            var pts = new PointF[tour.Size];

            for (int i = 0; i < tour.Size; i++)
            {
                var city = tour.Cities[i];
                var p1 = CreatePointF(city);

                g.FillEllipse(Brushes.White, new RectangleF(p1, new SizeF(6, 6)));
                pts[i] = p1;
            }

            g.DrawPolygon(Pens.White, pts);
        }

        private void SetDimensions()
        {
            double minX = double.MaxValue;
            double maxX = 0;
            double minY = double.MaxValue;
            double maxY = 0;

            for (int i = 0; i < CitiesHolder.Cities.Count; i++)
            {
                var city = CitiesHolder.Cities[i];

                if (city.X < minX)
                    minX = city.X;

                if (city.X > maxX)
                    maxX = city.X;

                if (city.Y < minY)
                    minY = city.Y;

                if (city.Y > maxY)
                    maxY = city.Y;
            }

            _widthOffset = minX >= 0 ? 0 : Math.Abs(minX);
            _heightOffset = minY >= 0 ? 0 : Math.Abs(minY);
            double maxWidth = maxX + _widthOffset;
            double maxHeight = maxY + _heightOffset;

            double x = ClientRectangle.Width / maxWidth;
            double y = (ClientRectangle.Height - statusStrip1.Height) / maxHeight;

            _zoomX = x >= 1 ? (float)x - 0.1f : 1;
            _zoomY = y >= 1 ? (float)y - 0.1f : 1;
        }

        private PointF CreatePointF(City city)
        {
            return new PointF((float)(city.X + _widthOffset) * _zoomX, (float)(city.Y + _heightOffset) * _zoomY);
        }

        private string GenerateSummary(double elapsed)
        {
            var sb = new StringBuilder();

            double bestDistance = _gaSolver.CurrentBestDistance;

            sb.AppendLine($"Finished in {elapsed / 1000} seconds.");
            sb.AppendLine($"Best distance found: {bestDistance} (Optimal: {_currentItem.OptimalTourDistance}).");

            double distanceGap = 0;
            try
            {
                distanceGap = (bestDistance - _currentItem.OptimalTourDistance) / bestDistance * 100;
            }
            catch
            {
                // Ignored
            }

            sb.AppendLine($"Distance GAP: {distanceGap}%");
            sb.AppendLine($"Best fitness found: {_gaSolver.CurrentBestFitness}.");

            sb.AppendLine();
            sb.AppendLine("Do you wish to save the results?");

            return sb.ToString();
        }

        private string GenerateResults(double elapsed)
        {
            var sb = new StringBuilder();

            double bestDistance = _gaSolver.CurrentBestDistance;
            double distanceGap = 0;

            try
            {
                distanceGap = (bestDistance - _currentItem.OptimalTourDistance) / bestDistance * 100;
            }
            catch
            {
                // Ignored
            }

            sb.AppendLine($"GENERATIONS\t{_gaSolver.Properties.MaxGenerations}");
            sb.AppendLine($"POPULATIONS_SIZE\t{_gaSolver.Properties.PopulationsSize}");
            sb.AppendLine($"TOURNAMENT_SIZE\t{_gaSolver.Properties.TournamentSize}");
            sb.AppendLine($"MUTATION_RATE\t{_gaSolver.Properties.MutationRate}");
            sb.AppendLine($"ELITISM\t{_gaSolver.Properties.Elitism}");

            sb.AppendLine($"TIME\t{elapsed}");
            sb.AppendLine($"BEST_DISTANCE\t{bestDistance}");
            sb.AppendLine($"BEST_FITNESS\t{_gaSolver.CurrentBestFitness}");
            sb.AppendLine($"DISTANCE_GAP\t{distanceGap}");

            sb.AppendLine($"DIMENSION\t{_gaSolver.FittestTour.Size}");
            _gaSolver.FittestTour.Cities.ForEach(c => sb.AppendLine(c.Id.ToString()));

            return sb.ToString();
        }

        #endregion

    }
}