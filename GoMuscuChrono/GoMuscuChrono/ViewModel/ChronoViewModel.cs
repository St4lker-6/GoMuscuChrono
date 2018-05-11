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

        private Timer _myTimer;
        private DateTime _counterTime;
        private readonly IEventAggregator _eventAggregator;

        public string DisplayedCounter
        {
            get
            {
                return _counterTime.ToString("mm") + " : " + _counterTime.ToString("ss"); 
            }
        }

        public ChronoViewModel()
        {
            _eventAggregator = ApplicationService.Instance.EventAggregator;
            _eventAggregator.GetEvent<TimerChangedEvent>().Subscribe(TimerChanged);

            this.StartCommand = new Command(this.StartCounter);
            this.PauseCommand = new Command(this.PauseCounter);
            this.StopCommand = new Command(this.StopCounter);

            _myTimer = new Timer();
            _myTimer.Elapsed += myTimerElapsed;
        }

        private void TimerChanged(TimerChangedEventArgs obj)
        {
            _counterTime = obj.SelectedTime.CounterTime;
            this.NotifyPropertyChanged(nameof(this.DisplayedCounter));
            this.StartCounter();

        }

        private void StartCounter()
        {
            _myTimer.Interval = 1000;
            _myTimer.Start();
        }

        private void myTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _myTimer.Stop();

            _counterTime = _counterTime.AddSeconds(-1);
            this.NotifyPropertyChanged(nameof(this.DisplayedCounter));

            if (_counterTime.Minute == 0 && _counterTime.Second == 0)
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
            _myTimer.Stop();
        }

        private void StopCounter()
        {
            _myTimer.Stop();
            _eventAggregator.GetEvent<TimerElapsedEvent>().Publish(null);
        }
    }
}
