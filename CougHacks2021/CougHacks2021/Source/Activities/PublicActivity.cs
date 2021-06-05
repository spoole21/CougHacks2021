using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021.Source.Activities
{
    public class PublicActivity : Activity
    {
        private int minTime;
        public PublicActivity()
        {

        }
        public PublicActivity(DateTime startTime, int minTime) : base(startTime)
        {
            this.minTime = minTime;
        }
    }
}
