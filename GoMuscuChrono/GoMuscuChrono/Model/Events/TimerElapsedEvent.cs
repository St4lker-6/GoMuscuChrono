using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoMuscuChrono.Model.Events
{
    public class TimerElapsedEvent : PubSubEvent<TimerElapsedEventArgs> { }

    public class TimerElapsedEventArgs : EventArgs
    {
        public TimerElapsedEventArgs()
        {
        }
    }
}
