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

            //int[] max_gens = { 30 };
            //int[] pop_sizes = { 20, 30 };
            //double[] mut_rates = { 0.01, 0.02 };
            //int[] tourn_sizes = { 2, 5, 8 };
            //bool[] elitism = { true, false };
            //CrossoverMethod[] crossover_methods = (CrossoverMethod[])Enum.GetValues(typeof(CrossoverMethod));
            //InitialPopulationMethod[] initial_pop_methods = (InitialPopulationMethod[])Enum.GetValues(typeof(InitialPopulationMethod));
            //MutationMethod[] mut_methods = (MutationMethod[]) Enum.GetValues(typeof(MutationMethod));
            //SelectionMethod[] sel_methods = (SelectionMethod[]) Enum.GetValues(typeof(SelectionMethod));

            //int total_possibilities = max_gens.Length * pop_sizes.Length * mut_rates.Length * tourn_sizes.Length * elitism.Length * crossover_methods.Length *
            //                          initial_pop_methods.Length * mut_methods.Length * sel_methods.Length;

            //foreach (int max_gen in max_gens)
            //{
            //    foreach (int pop_size in pop_sizes)
            //    {
            //        foreach (double mut_rate in mut_rates)
            //        {
            //            foreach (int tourn_size in tourn_sizes)
            //            {
            //                foreach (bool elit in elitism)
            //                {
            //                    foreach (CrossoverMethod crossover in crossover_methods)
            //                    {
            //                        foreach (InitialPopulationMethod ipm in initial_pop_methods)
            //                        {
            //                            foreach (MutationMethod mutation in mut_methods)
            //                            {
            //                                foreach (SelectionMethod selectin in sel_methods)
            //                                {
                                                
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

        }
    }
}
