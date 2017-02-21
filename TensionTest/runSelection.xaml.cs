using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using AdhesionTest.Properties;

namespace AdhesionTest
{
    /// <summary>
    ///     Interaction logic for runSelection.xaml
    /// </summary>
    public partial class runSelection : Page
    {
        public runSelection()
        {
            InitializeComponent();
            if (Settings.Default.filePath == "")
            {
                Settings.Default.filePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            }
            fileLocationText.Content = Settings.Default.filePath;
        }

        private void editFileButton_Click(object sender, RoutedEventArgs e)
        {
            var folderBrowser = new FolderBrowserDialog();
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer;
            var result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileLocationText.Content = folderBrowser.SelectedPath;
                Settings.Default.filePath = folderBrowser.SelectedPath;
                Settings.Default.Save();
            }
        }

        private void TextBoxPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!sanitizeInput(e.Text))
            {
                //Invalid input
                e.Handled = true;
            }
        }

        /// <summary>
        ///     Ensures that only numbers/decimals are input
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns>Returns true if valid</returns>
        private bool sanitizeInput(string inputString)
        {
            if (!char.IsDigit(inputString, inputString.Length - 1) &&
                !(inputString.ElementAt(inputString.Length - 1) == '.') &&
                !(inputString.ElementAt(inputString.Length - 1) == '-'))
            {
                return false;
            }
            return true;
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.mainFrame.Navigate(new calibration());
        }

        private void trialButtonClick(object sender, RoutedEventArgs e)
        {
            var trial = new trialManager();
            trial = updateTrialSettings(trial);
            MainWindow.mainFrame.Navigate(trial);
        }



        private trialManager updateTrialSettings(trialManager trial)
        {
            trial.velocity = Convert.ToDouble(velocityBox.Text);
            trial.collectFullData = Convert.ToBoolean(fullDataBox.IsChecked);            
            return trial;
        }

        private void acceleratedMotionBox_Checked(object sender, RoutedEventArgs e)
        {
            if (accelSpeedGrid.Visibility == Visibility.Hidden)
                accelSpeedGrid.Visibility = Visibility.Visible;
            else
                accelSpeedGrid.Visibility = Visibility.Hidden;
        }
    }
}