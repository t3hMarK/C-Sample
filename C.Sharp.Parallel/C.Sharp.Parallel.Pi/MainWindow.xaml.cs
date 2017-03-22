using System.Collections.Concurrent;
using System.Threading.Tasks;
using System.Windows;

namespace C.Sharp.Parallel.Pi
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constants

        private const int NUM_STEPS = int.MaxValue;

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Event Handling

        private void sync_button_Click(object sender, RoutedEventArgs e)
        {
            result_label.Content = "Executing Sync";

            double result = Pi();
            result_label.Content = result.ToString();
        }

        private async void async_button_Click(object sender, RoutedEventArgs e)
        {
            result_label.Content = "Executing Async";

            double result = await PiAsync();
            result_label.Content = result.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Make Pi
        /// </summary>
        /// <returns>Pi</returns>
        /// <remarks>Disclaimer : Pi is not edible</remarks>
        private double Pi()
        {
            double sum = 0.0;
            double step = 1.0 / NUM_STEPS;

            //Compute Pi using parallel map/reduce scheme through a Partitioner
            object monitor = new object();
            System.Threading.Tasks.Parallel.ForEach(Partitioner.Create(0, NUM_STEPS), () => 0d, (range, state, local) =>
            {
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    double x = (i + 0.5) * step;
                    local += 4.0 / (1.0 + x * x);
                }
                return local;
            }, local => { lock (monitor) sum += local; });

            return step * sum;
        }

        /// <summary>
        /// Make Pi while doing the other stuff too!!
        /// </summary>
        /// <returns>Pi but later...</returns>
        /// <remarks>Disclaimer : Async Pi is stil not edible</remarks>
        private async Task<double> PiAsync() => await Task.Run(() => Pi());

        #endregion        
    }
}
