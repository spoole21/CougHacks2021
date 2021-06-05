using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021
{
    public abstract class Activity
    {
        private DateTime startTime;
        private DateTime endTime;

        public Activity()
        {}

        public Activity(DateTime startTime)
        {
            this.endTime = new DateTime(0, 0, 0, 21, 0, 0);
        }
       
    }
}
