using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.GreedyAlgos
{
    class ActivitySelection
    {
        static void Main(string[] args)
        {
            var activities = new List<Activity>();
            activities.Add(new Activity { Name = "A1", StartTime = 0, EndTime = 6 });
            activities.Add(new Activity { Name = "A2", StartTime = 3, EndTime = 4 });
            activities.Add(new Activity { Name = "A3", StartTime = 1, EndTime = 2 });
            activities.Add(new Activity { Name = "A4", StartTime = 5, EndTime = 8 });
            activities.Add(new Activity { Name = "A5", StartTime = 5, EndTime = 7 });
            activities.Add(new Activity { Name = "A6", StartTime = 8, EndTime = 9 });

            MaxActivityPerformedBySinglePerson(activities);
        }

        private static void MaxActivityPerformedBySinglePerson(List<Activity> activities)
        {
            var comparer = new ActivityComparer();
            activities.Sort(comparer);

            var previousActivity = activities[0];
            Console.Write(previousActivity.Name + " ");
            
            for(int i=1; i<activities.Count;i++)
            {
                var currentActivity = activities[i];
                if(currentActivity.StartTime >= previousActivity.EndTime)
                {
                    Console.Write(currentActivity.Name + " ");
                    previousActivity = currentActivity;
                }
            }
        }
    }

    public class ActivityComparer : IComparer<Activity>
    {
        public int Compare(Activity x, Activity y)
        {
            return x.EndTime.CompareTo(y.EndTime);
        }
    }

    public class Activity
    {
        public string Name { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}
