using System;
using System.Collections.Generic;
using System.Text;

namespace GoMuscuChrono.Model.Events
{
    public class SetNumberChangedEventArgs : EventArgs
    {
        public SetClass SelectedSet { get; set; }

        public SetNumberChangedEventArgs(SetClass selectedSet)
        {
            this.SelectedSet = selectedSet;
        }
    }

}
