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

        private TimeListViewModel _timeListViewModel;
        public TimeListViewModel TimeListViewModel
        {

            get
            {
                return _timeListViewModel;
            }
            set
            {
                if (_timeListViewModel != value)
                {
                    _timeListViewModel = value;
                    this.NotifyPropertyChanged(nameof(TimeListViewModel));
                }
            }
        }

        private ChronoViewModel _chronoViewModel;
        public ChronoViewModel ChronoViewModel
        {

            get
            {
                return _chronoViewModel;
            }
            set
            {
                if (_chronoViewModel != value)
                {
                    _chronoViewModel = value;
                    this.NotifyPropertyChanged(nameof(ChronoViewModel));
                }
            }
        }

        private SetViewModel _setViewModel;
        public SetViewModel SetViewModel
        { 
            get
            {
                return _setViewModel;
            }
            set
            {
                if (_setViewModel != value)
                {
                    _setViewModel = value;
                    this.NotifyPropertyChanged(nameof(SetViewModel));
                }
            }
        }

        public MainPageViewModel()
        {
            this.ChronoViewModel = new ChronoViewModel();
            this.TimeListViewModel = new TimeListViewModel();
            this.SetViewModel = new SetViewModel();

            this.ChronoViewModel.TimerStopped += ChronoViewModel_TimerStopped;
            this.TimeListViewModel.TimerValueChanged += TimeListViewModel_TimerValueChanged;

            this.DisplayMode = DisplayModeEnum.TimerSelection;
        }

        private void TimeListViewModel_TimerValueChanged(object sender, EventArgs e)
        {
            var eventArgs = (TimerChangedEventArgs)e;

            this.DisplayMode = DisplayModeEnum.TimerCount;
            this.ChronoViewModel.TimerChanged(eventArgs);
        }

        private void ChronoViewModel_TimerStopped(object sender, EventArgs e)
        {
            this.DisplayMode = DisplayModeEnum.TimerSelection;
            this.SetViewModel.TimerStopped();
        }
    }
}
