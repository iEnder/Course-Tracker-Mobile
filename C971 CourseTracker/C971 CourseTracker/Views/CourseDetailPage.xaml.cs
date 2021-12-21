
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CourseDetailPage : ContentPage
    {
        private ViewModels.CourseDetailViewModel _viewModel;

        public CourseDetailPage(int id)
        {
            InitializeComponent();
            BindingContext = _viewModel = new ViewModels.CourseDetailViewModel(id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}