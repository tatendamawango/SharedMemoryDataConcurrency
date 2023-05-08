using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L1_A
{
    class StudentComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return new CaseInsensitiveComparer().Compare(((Student)x).Name, ((Student)y).Name);
        }
    }

}
