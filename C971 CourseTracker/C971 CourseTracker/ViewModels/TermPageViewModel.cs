using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace C971_CourseTracker.ViewModels
{
    class TermPageViewModel : BaseModel
    {
        public ObservableCollection<Models.Term> Terms { get; set; }
        public ICommand SetRoute { get; }

        public TermPageViewModel()
        {
            Terms = new ObservableCollection<Models.Term>();
            SetRoute = new Command<Models.Term>(OnTermTap);
            LoadItems = new Command(async () => await ExecLoadItems());
            RouteModify = new Command<Models.Term>(OnCogTap);
            RouteAdd = new Command(OnAddTap);
            Title = "Terms";
        }

        private async void OnAddTap()
        {
            await nav.PushAsync(new Views.ModifyTermPage(new Models.Term(), true));
        }

        private async void OnCogTap(Models.Term data)
        {
            await nav.PushAsync(new Views.ModifyTermPage(data));
        }

        private async void OnTermTap(Models.Term t)
        {
            await nav.PushAsync(new Views.CoursePage(t.id));
        }

        private async Task ExecLoadItems()
        {
            IsBusy = true;
            try
            {
                Terms.Clear();
                IEnumerable<Models.Term> _terms = await CourseDB.GetTerms();
                foreach (Models.Term term in _terms)
                {
                    Terms.Add(term);
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
