using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace CoolTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _startTimer = false;
        private bool _isChill = false;


        private int _hours = 1;
        private int _minutes = 0;
        private int _seconds = 0;
    

        private int increment = 0;
        private DispatcherTimer _timer = new DispatcherTimer();
        

        public MainWindow()
        {
            InitializeComponent();

            increment = (_hours * 60 * 60) + (_minutes * 60) + _seconds;
            durationTimer.Text = $"{_hours:00}:{_minutes:00}:{_seconds:00}";

            _timer.Tick += timerTick;
            _timer.Interval = TimeSpan.FromSeconds(1);
        }

        private void timerTick(object? sender, EventArgs e)
        {
            increment--;

            _seconds--;
            if(_seconds == -1)
            {
                _minutes--;
                _seconds = 59;
            }
            if (_minutes == -1)
            {
                _hours--;
                _minutes = 59;
            }

            if (_hours == -1)
            {
                if (!_isChill)
                {
                    _isChill = !_isChill;
                    startChill();
                }
                else
                {
                    _isChill = !_isChill;
                    startWorking();
                }                    
            }
                
            

            durationTimer.Text = $"{_hours:00}:{_minutes:00}:{_seconds:00}";
        }

        private void startWorking()
        {
            MessageBox.Show("Время отдыха окончено", "Опа", MessageBoxButton.OK);
            _hours = 1;
            _minutes = 0;
            _seconds = 0;
        }

        private void startChill()
        {
            MessageBox.Show("Время работы окончено", "Опа", MessageBoxButton.OK);
            _hours = 0;
            _minutes = 20;
            _seconds = 0;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void startStopBtn_Click(object sender, RoutedEventArgs e)
        {
            switch (_startTimer)
            {
                case false: _startTimer = true; _timer.Start(); break;
                case true: _startTimer = false; _timer.Stop(); break;
            }
        }

        private void durationTimer_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isChill = false;
            _startTimer = false;
            _timer.Stop();
            _hours = 1;
            _minutes = 0;
            _seconds = 0;
            durationTimer.Text = $"{_hours:00}:{_minutes:00}:{_seconds:00}";
        }
    }
}
