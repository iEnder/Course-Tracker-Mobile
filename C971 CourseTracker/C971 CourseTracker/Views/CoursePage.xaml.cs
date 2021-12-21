
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CoursePage : ContentPage
    {
        ViewModels.CoursePageViewModel _viewModel;

        public CoursePage(int id)
        {
            InitializeComponent();
            BindingContext = _viewModel = new ViewModels.CoursePageViewModel(id);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}