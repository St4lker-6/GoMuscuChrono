using GoMuscuChrono.Model.Events;
using GoMuscuChrono.Model.Services;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoMuscuChrono.ViewModel
{
    public class ChronoViewModel : ViewModelBase
    {
        public ICommand StartCommand { get; protected set; }
        public ICommand PauseCommand { get; protected set; }
        public ICommand StopCommand { get; protected set; }

        private Timer _timer;
        private DateTime timerValue;

        public event EventHandler TimerStopped;

        public string DisplayedCounter
        {
            get
            {
                return timerValue.ToString("mm") + " : " + timerValue.ToString("ss");
            }
        }

        private bool _timerPaused;
        public bool TimerPaused
        {

            get
            {
                return _timerPaused;
            }
            set
            {
                if (_timerPaused != value)
                {
                    _timerPaused = value;
                    this.NotifyPropertyChanged(nameof(TimerPaused));
                }
            }
        }

        public ChronoViewModel()
        {
            this.StartCommand = new Command(this.StartCounter);
            this.PauseCommand = new Command(this.PauseCounter);
            this.StopCommand = new Command(this.StopCounter);

            _timer = new Timer();
            _timer.Elapsed += myTimerElapsed;
        }

        public void TimerChanged(TimerChangedEventArgs obj)
        {
            timerValue = obj.SelectedTime.CounterTime;
            this.NotifyPropertyChanged(nameof(this.DisplayedCounter));
            this.StartCounter();

        }

        private void StartCounter()
        {
            _timer.Interval = 1000;
            _timer.Start();
        }

        private void myTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();

            timerValue = timerValue.AddSeconds(-1);
            this.NotifyPropertyChanged(nameof(this.DisplayedCounter));

            if (timerValue.Minute == 0 && timerValue.Second == 0)
            {
                this.StopCounter();
            }
            else
            {
                this.StartCounter();
            }
        }

        private void PauseCounter()
        {
            if (TimerPaused)
            {
                this.TimerPaused = false;
                _timer.Start();
            }
            else
            {
                this.TimerPaused = true;
                _timer.Stop();
            }
        }

        private void StopCounter()
        {
            _timer.Stop();

            TimerStopped?.Invoke(this, new TimerElapsedEventArgs());
        }
    }
}
