using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021.Source.Activities
{
    public class Gym : PublicActivity
    {
        public Gym(DateTime startTime, int minTime) : base(startTime, minTime)
        {
            minTime = 60;
        }
    }
}
