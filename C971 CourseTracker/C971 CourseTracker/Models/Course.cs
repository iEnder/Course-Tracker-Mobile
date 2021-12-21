using Plugin.LocalNotifications;
using System;
using System.Threading.Tasks;

namespace C971_CourseTracker.Models
{
    public class Course : BaseDataModel
    {
        public string name { get; set; }

        private DateTime _startDate;
        public DateTime startDate
        {
            get => _startDate;
            set
            {
                if (value != _startDate)
                {
                    int notifId = int.Parse($"103{this.id}");
                    CrossLocalNotifications.Current.Cancel(notifId);
                    if (value > DateTime.Now)
                    {
                        CrossLocalNotifications.Current.Show("Course Date", $"Course {name} starting in 1 day!", notifId, value.AddDays(-1));
                    }
                }
                _startDate = value;
            }
        }

        private DateTime _endDate;
        public DateTime endDate
        {
            get => _endDate;
            set
            {
                if (value != _endDate)
                {
                    int notifId = int.Parse($"101{this.id}");
                    CrossLocalNotifications.Current.Cancel(notifId);
                    if (value > DateTime.Now)
                    {
                        CrossLocalNotifications.Current.Show("Course Date", $"Course {name} ending in 1 day!", notifId, value.AddDays(-1));
                    }
                }
                _endDate = value;
            }
        }

        public string CourseDate => $"{startDate:M/dd/yyyy} - {endDate:M/dd/yyyy}";
        public string status { get; set; }
        public string instuctorName { get; set; }
        public string instuctorPhone { get; set; }
        public string instuctorEmail { get; set; }
        public int termId { get; set; }

        public static implicit operator Course(Task<Course> v)
        {
            throw new NotImplementedException();
        }
    }
}
