using System;
using System.Collections.Generic;
using System.Text;

namespace GoMuscuChrono.Model
{
    public class TimeClass
    {
        public DateTime CounterTime { get; set; }

        public string DisplayedTime
        {
            get
            {
                return CounterTime.ToString("mm") + " : " + CounterTime.ToString("ss");
            }
        }
    }
}
