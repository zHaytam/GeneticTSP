using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TspLibNet;
using TspLibNet.Graph.Nodes;

namespace GeneticTSP
{
    public partial class MainForm : Form
    {

        #region Fields

        private List<TspLib95Item> _tspItems;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        #region UI Events

        private void TsmiLoadProblems_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
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
                        var newMenuItem = new ToolStripMenuItem
                        {
                            Text = item.Problem.Name,
                            Tag = item
                        };

                        newMenuItem.Click += SelectProblem_Click;
                        TsmiSelectProblem.DropDownItems.Add(newMenuItem);
                    }

                    TsmiSelectProblem.Enabled = true;

                }
                catch
                {
                    MessageBox.Show("An error occured.\nDid you select the right folder?", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void SelectProblem_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripMenuItem)?.Tag as TspLib95Item;
            var nodesProvider = item?.Problem.NodeProvider as NodeListBasedNodeProvider;
            CitiesHolder.SetCities(nodesProvider);

            var solver = new GASolver();
            solver.Solve();
        }

        #endregion

    }
}
