using System;
using System.Collections.Generic;
using System.Text;

namespace GoMuscuChrono.Model
{
    public class SetClass
    {
        public int SetNumber { get; set; }
        public bool IsCurrentSet { get; set; }

        public string DisplayedSet
        {
            get
            {
                return SetNumber.ToString();
            }
        }
    }
}
