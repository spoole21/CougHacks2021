using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021
{
    public class Arrival
    {
        public List<List<bool>> desiredTime;
        public List<List<bool>> desiredAttendanceTime;
        public List<List<bool>> realTime;
        private List<Activity> activities;

        public Arrival(List<List<bool>> desiredTime, List<List<bool>> desiredAttendanceTime)
        {

            this.desiredTime = desiredTime;
            this.desiredAttendanceTime = desiredAttendanceTime;
        }
        public void addActivity(Activity activity)
        {
            this.activities.Add(activity);
        }
        
    }
}
