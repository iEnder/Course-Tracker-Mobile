using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace C971_CourseTracker.ViewModels
{
    class CoursePageViewModel : BaseModel
    {
        public int TermID { get; set; }
        public ICommand SetRoute { get; }
        public ObservableCollection<Models.Course> Courses { get; set; }

        public CoursePageViewModel(int _termId)
        {
            Courses = new ObservableCollection<Models.Course>();
            SetRoute = new Command<Models.Course>(OnCourseTap);
            LoadItems = new Command(async () => await ExecLoadItems());
            RouteModify = new Command<Models.Course>(OnModifyTap);
            RouteAdd = new Command(OnAddTap);

            Title = "Courses";
            TermID = _termId;
        }

        private async void OnAddTap()
        {
            await nav.PushAsync(new Views.ModifyCoursePage(new Models.Course() { termId = TermID }, true));
        }

        private async void OnCourseTap(Models.Course _course)
        {
            await nav.PushAsync(new Views.CourseDetailPage(_course.id));
        }

        private async void OnModifyTap(Models.Course data)
        {
            await nav.PushAsync(new Views.ModifyCoursePage(data));
        }

        private async Task ExecLoadItems()
        {
            IsBusy = true;
            try
            {
                Courses.Clear();
                IEnumerable<Models.Course> items = await CourseDB.GetCourses(TermID);
                foreach (var item in items)
                {
                    Courses.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
            IsBusy = false;
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}
