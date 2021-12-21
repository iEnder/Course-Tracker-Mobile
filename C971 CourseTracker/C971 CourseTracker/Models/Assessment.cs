using Plugin.LocalNotifications;
using System;

namespace C971_CourseTracker.Models
{
    public partial class Assessment : BaseDataModel
    {
        public string name { get; set; }

        public int courseId { get; set; }

        private DateTime _dueDate;
        public DateTime dueDate
        {
            get => _dueDate;
            set
            {
                if (value != _dueDate)
                {
                    int notifId = int.Parse($"205{this.id}");
                    CrossLocalNotifications.Current.Cancel(notifId);
                    if (value > DateTime.Now)
                    {
                        CrossLocalNotifications.Current.Show("Course Date", $"Course {name} due in 1 day!", notifId, value.AddDays(-1));
                    }
                }
                _dueDate = value;
            }
        }

        public string type { get; set; }
    }

}
