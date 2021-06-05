using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CougHacks2021.Source
{
    public class Scheduler
    {

        private List<Arrival> arrivals;
        public MainWindow window = new MainWindow();

        public Scheduler()
        {
            arrivals = new List<Arrival>();
        }
        public void getSchedule()
        {
            processAttendenceTime();
        }
        public void addArrival(Arrival arrival)
        {
            this.arrivals.Add(arrival);
        }


        private void processAttendenceTime()
        {

            for (int eevent = 0; eevent < 6; eevent++)
            {
                for (int times = 0; times < 35; times++)
                {
                    for (int person = 0; person < 3; person++)
                    {
                        if (window.plannerTabSelected())
                        {
                            while ((Convert.ToInt32(arrivals[0].desiredTime[eevent][times]) +
                            Convert.ToInt32(arrivals[1].desiredTime[eevent][times]) +
                            Convert.ToInt32(arrivals[2].desiredTime[eevent][times])) > 1)
                            {
                                //arrivals[temp].desiredTime[eevent][times] = false;
                                Console.WriteLine("LOOP");
                                int count1 = getCount(arrivals[0].desiredTime[eevent]);
                                int count2 = getCount(arrivals[1].desiredTime[eevent]);
                                int count3 = getCount(arrivals[2].desiredTime[eevent]);

                                int biggest = count1;

                                if (count1 > count2)
                                {

                                    if (count1 > count3)
                                    {
                                        //count1 is bigger
                                        biggest = 0;
                                    }
                                    else
                                    {
                                        //count3 is bigger
                                        biggest = 2;
                                    }
                                }
                                else
                                {
                                    if (count2 > count3)
                                    {
                                        //count2 is bigger
                                        biggest = 1;
                                    }
                                    else
                                    {
                                        //count3 is bigger
                                        biggest = 2;
                                    }
                                }

                                arrivals[biggest].desiredTime[eevent][times] = false;

                            }
                        }
                        else
                        {
                            while ((Convert.ToInt32(arrivals[0].desiredAttendanceTime[eevent][times]) +
                            Convert.ToInt32(arrivals[1].desiredAttendanceTime[eevent][times]) +
                            Convert.ToInt32(arrivals[2].desiredAttendanceTime[eevent][times])) > 1)
                            {
                                //arrivals[temp].desiredTime[eevent][times] = false;
                                Console.WriteLine("LOOP");
                                int count1 = getCount(arrivals[0].desiredAttendanceTime[eevent]);
                                int count2 = getCount(arrivals[1].desiredAttendanceTime[eevent]);
                                int count3 = getCount(arrivals[2].desiredAttendanceTime[eevent]);

                                int biggest = count1;

                                if (count1 > count2)
                                {

                                    if (count1 > count3)
                                    {
                                        //count1 is bigger
                                        biggest = 0;
                                    }
                                    else
                                    {
                                        //count3 is bigger
                                        biggest = 2;
                                    }
                                }
                                else
                                {
                                    if (count2 > count3)
                                    {
                                        //count2 is bigger
                                        biggest = 1;
                                    }
                                    else
                                    {
                                        //count3 is bigger
                                        biggest = 2;
                                    }
                                }

                                arrivals[biggest].desiredAttendanceTime[eevent][times] = false;

                            }
                        }
                    }
                }
            }
        }


        private int getCount(List<bool> list)
        {
            int count = 0;
            foreach (bool item in list)
            {
                if (item)
                {
                    count++;
                }
            }
            return count;
        }

        private int addColumn()
        {
            return 0;
        }
    }
}

