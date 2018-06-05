using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoMuscuChrono.Model.Events
{
    public class TimerChangedEventArgs : EventArgs
    {
        public TimeClass SelectedTime { get; set; }

        public TimerChangedEventArgs(TimeClass selectedTime)
        {
            SelectedTime = selectedTime;
        }
    }
}
