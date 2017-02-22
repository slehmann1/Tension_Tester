using System;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using Timer = System.Timers.Timer;

namespace TensionTest
{
    /// <summary>
    ///     Interaction logic for trialViewer.xaml
    /// </summary>
    public partial class trialViewer : Page
    {
        private readonly DateTime startTime;
        private readonly trialManager trial;

        public trialViewer(trialManager trial)
        {
            InitializeComponent();
            MainViewModel.normalForceLabel = normalForceLabel;
            MainViewModel.shearForceLabel = shearForceLabel;
            this.trial = trial;


            var myTimer = new Timer();
            myTimer.Elapsed += timer_Tick;
            myTimer.Interval = 1000;
            myTimer.Start();

            startTime = DateTime.Now;

            var trialThread = new Thread(trial.runTrial);
            trialThread.IsBackground = true;
            trialThread.Start();
        }

        private void timer_Tick(object sender, ElapsedEventArgs e)
        {
            //This is done with a dispatcher for thread safety
            Dispatcher.Invoke(() =>
            {
                var timeDiff = DateTime.Now - startTime;
                elapsedTimeText.Text = "Time elapsed: " + ((int)timeDiff.TotalMinutes).ToString("0") + " minutes and " +
                                       (timeDiff.TotalSeconds % 60).ToString("0") + " seconds";
            });
        }



        

        private void stopTrialClick(object sender, RoutedEventArgs e)
        {
            trial.abortTrial();
            MainWindow.mainFrame.Navigate(new trialComplete()); //Move back to the start
        }
    }
}