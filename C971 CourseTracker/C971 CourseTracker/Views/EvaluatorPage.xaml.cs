using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EvaluatorPage : ContentPage
    {
        public EvaluatorPage()
        {
            InitializeComponent();
            BindingContext = new ViewModels.EvaluatorPageViewModel();
        }
    }
}