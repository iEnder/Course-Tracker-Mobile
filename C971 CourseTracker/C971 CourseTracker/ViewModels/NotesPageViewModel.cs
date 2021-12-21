using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace C971_CourseTracker.ViewModels
{
    public class NotesPageViewModel : BaseModel
    {
        public ICommand RouteAddNote { get; }
        protected int CourseID { get; set; }

        public ObservableCollection<Models.Note> Notes { get; set; }

        public NotesPageViewModel(int _courseId)
        {
            Notes = new ObservableCollection<Models.Note>();
            LoadItems = new Command(async () => await ExecLoadItems());
            RouteModify = new Command<Models.Note>(OnCogTap);
            RouteAddNote = new Command(OnAddTap);

            Title = "Notes";
            CourseID = _courseId;
        }
        private async void OnCogTap(Models.Note note)
        {
            await nav.PushAsync(new Views.ModifyNotePage(note));
        }

        private async void OnAddTap()
        {
            await nav.PushAsync(new Views.ModifyNotePage(new Models.Note() { courseId = CourseID }, true));
        }

        private async Task ExecLoadItems()
        {
            IsBusy = true;
            try
            {
                Notes.Clear();
                IEnumerable<Models.Note> items = await CourseDB.GetNotes(CourseID);
                foreach (var item in items)
                {
                    Notes.Add(item);
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
