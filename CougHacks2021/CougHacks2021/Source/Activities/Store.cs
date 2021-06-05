using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021
{
    public class Store : SingleActivity
    {
        public Store(DateTime startTime, int duration) : base(startTime, duration)
        {
            duration = 30;
        }
    }
}
