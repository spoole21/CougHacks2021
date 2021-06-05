using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021
{
    public class SingleActivity : Activity
    {
        private int duration;
        public SingleActivity(DateTime startTime, int duration) : base(startTime)
        {
            this.duration = duration;
        }
    }
}
