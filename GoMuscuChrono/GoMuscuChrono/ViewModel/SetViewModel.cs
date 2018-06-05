using GoMuscuChrono.Model;
using GoMuscuChrono.Model.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace GoMuscuChrono.ViewModel
{
    public class SetViewModel : ViewModelBase
    {
        public ICommand AddSetCommand { get; protected set; }
        public ICommand RemoveSetCommand { get; protected set; }

        private int _setValue;
        public int SetValue
        {
            get
            {
                return _setValue;
            }
            set
            {
                if (_setValue != value)
                {
                    _setValue = value;
                    this.NotifyPropertyChanged(nameof(this.SetValue));
                }
            }
        }

        public SetViewModel()
        {
            this.AddSetCommand = new Command(this.AddSet);
            this.RemoveSetCommand = new Command(this.RemoveSet);
        }

        internal void TimerStopped()
        {
            if (this.SetValue > 0)
            {
                this.SetValue--;
            }
        }

        private void AddSet()
        {
            this.SetValue++;
        }

        private void RemoveSet()
        {
            if (this.SetValue > 0)
            {
                this.SetValue--;
            }
        }
    }
}
