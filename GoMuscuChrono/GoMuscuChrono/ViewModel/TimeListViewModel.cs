﻿using GoMuscuChrono.Model;
using GoMuscuChrono.Model.Events;
using GoMuscuChrono.Model.Services;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoMuscuChrono.ViewModel
{
    public class TimeListViewModel : ViewModelBase
    {
        public ICommand SelectedTimeCommand { get; protected set; }

        private ObservableCollection<TimeClass> _timeList;
        public ObservableCollection<TimeClass> TimeList
        {
            get
            {
                return _timeList;
            }
            set
            {
                if (_timeList != value)
                {
                    _timeList = value;
                    this.NotifyPropertyChanged(nameof(this.TimeList));
                }
            }
        }

        private TimeClass _selectedTime;
        public TimeClass SelectedTime
        {
            get
            {
                return _selectedTime;
            }
            set
            {
                if (_selectedTime != value)
                {
                    _selectedTime = value;
                    this.NotifyPropertyChanged(nameof(this.SelectedTime));
                }
            }
        }

        public event EventHandler TimerValueChanged;

        public TimeListViewModel()
        {
            this.SelectedTimeCommand = new Command(this.SelectedTimeChanged);

            this.CreateTimeList();
        }

        private void CreateTimeList()
        {
            this.TimeList = new ObservableCollection<TimeClass>();

            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1957, 1, 9, 0, 0, 30) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1958, 4, 1, 0, 1, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1992, 12, 11, 0, 1, 30) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1991, 12, 25, 0, 2, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
            this.TimeList.Add(new TimeClass() { CounterTime = new DateTime(1987, 1, 12, 0, 3, 00) });
        }


        private void SelectedTimeChanged()
        {
            TimerValueChanged?.Invoke(this, new TimerChangedEventArgs(this.SelectedTime));
        }
    }
}
