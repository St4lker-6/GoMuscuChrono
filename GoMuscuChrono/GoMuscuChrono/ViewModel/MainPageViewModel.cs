using GoMuscuChrono.Model.Enum;
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
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;

        private DisplayModeEnum _displayMode;
        public DisplayModeEnum DisplayMode
        {

            get
            {
                return _displayMode;
            }
            set
            {
                if (_displayMode != value)
                {
                    _displayMode = value;
                    this.NotifyPropertyChanged(nameof(DisplayMode));
                }
            }
        }

        public MainPageViewModel()
        {
            _eventAggregator = ApplicationService.Instance.EventAggregator;
            _eventAggregator.GetEvent<TimerChangedEvent>().Subscribe(TimerChanged);
            _eventAggregator.GetEvent<TimerElapsedEvent>().Subscribe(TimerElapsed);

            this.DisplayMode = DisplayModeEnum.TimerSelection;
        }

        private void TimerChanged(TimerChangedEventArgs obj)
        {
            this.DisplayMode = DisplayModeEnum.TimerCount;

        }

        private void TimerElapsed(TimerElapsedEventArgs arg = null)
        {
            this.DisplayMode = DisplayModeEnum.TimerSelection;
        }
    }
}
