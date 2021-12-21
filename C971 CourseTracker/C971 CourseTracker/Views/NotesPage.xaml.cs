
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        ViewModels.NotesPageViewModel _viewModel;

        public NotesPage(int courseId)
        {
            InitializeComponent();
            BindingContext = _viewModel = new ViewModels.NotesPageViewModel(courseId);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

    }
}