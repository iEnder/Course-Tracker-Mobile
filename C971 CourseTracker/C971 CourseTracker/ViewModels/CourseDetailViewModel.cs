using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace C971_CourseTracker.ViewModels
{
    public class CourseDetailViewModel : BaseModel
    {
        public int CourseID { get; set; }

        private Models.Course _course = new Models.Course();
        public Models.Course Course
        {
            get => _course;
            set { SetProperty(ref _course, value); }
        }

        public ICommand GetCourse { get; }
        public ICommand ShowNotes { get; }
        public ICommand RouteModifyCourse { get; set; }

        public ObservableCollection<Models.Assessment> Assessments { get; set; }
        public string CourseDate => $"{Course.startDate:M/dd/yyyy} - {Course.endDate:M/dd/yyyy}";

        public CourseDetailViewModel(int _courseId)
        {
            Assessments = new ObservableCollection<Models.Assessment>();

            LoadItems = new Command(async () => await ExecGetData());
            RouteModifyCourse = new Command<Models.Course>(OnModifyTap);
            RouteModify = new Command<Models.Assessment>(OnCogTap);
            ShowNotes = new Command(PushNotesPage);
            RouteAdd = new Command(OnAddTap);

            CourseID = _courseId;
            Title = "Course";
        }

        private async void OnAddTap()
        {
            await nav.PushAsync(new Views.ModifyAssessmentPage(new Models.Assessment() { courseId = CourseID }, true));
        }

        private async void OnModifyTap(Models.Course data)
        {
            await nav.PushAsync(new Views.ModifyCoursePage(data));
        }

        private async void OnCogTap(Models.Assessment data)
        {
            await nav.PushAsync(new Views.ModifyAssessmentPage(data));
        }

        private async Task ExecGetData()
        {
            IsBusy = true;
            try
            {
                Assessments.Clear();
                IEnumerable<Models.Assessment> items = await CourseDB.GetAssessments(CourseID);
                foreach (var item in items)
                {
                    Assessments.Add(item);
                }
                Course = await CourseDB.GetCourse(CourseID);
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

        private async void PushNotesPage()
        {
            await nav.PushAsync(new Views.NotesPage(Course.id));
        }
    }
}
