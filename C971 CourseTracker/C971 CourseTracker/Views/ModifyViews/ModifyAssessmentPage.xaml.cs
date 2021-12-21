using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyAssessmentPage : ContentPage
    {
        public ModifyAssessmentPage(Models.Assessment _data, bool _new = false)
        {
            InitializeComponent();
            BindingContext = new ViewModels.ModifyAssessmentPageViewModel(_data, _new);
        }
    }
}