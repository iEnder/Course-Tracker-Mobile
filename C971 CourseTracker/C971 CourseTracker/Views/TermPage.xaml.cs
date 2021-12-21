using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TermPage : ContentPage
    {
        ViewModels.TermPageViewModel _viewModel;

        public TermPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ViewModels.TermPageViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}