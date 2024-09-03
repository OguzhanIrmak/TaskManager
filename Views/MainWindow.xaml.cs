using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using TaskTurner.ViewModels;

namespace TaskTurner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeSpan elapsedTime;

        public MainWindow()
        {
            InitializeComponent();
            InitializeClock();

            this.DataContext = new TaskViewModel();
        }

        private void InitializeClock()
        {
            timer = new DispatcherTimer();
            timer.Interval=TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;

            elapsedTime=TimeSpan.Zero;
            UpdateClockText();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           elapsedTime=elapsedTime.Add(TimeSpan.FromSeconds(1));
            UpdateClockText();
        }
        private void UpdateClockText()
        {
            ClockText.Text = elapsedTime.ToString(@"hh\:mm\:ss");
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            ClockText.Foreground=new SolidColorBrush(Colors.DarkRed);
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            ClockText.Foreground=new SolidColorBrush(Colors.Black);
        }
    }
}
