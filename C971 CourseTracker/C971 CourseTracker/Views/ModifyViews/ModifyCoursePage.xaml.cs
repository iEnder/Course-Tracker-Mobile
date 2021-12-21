
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyCoursePage : ContentPage
    {
        public ModifyCoursePage(Models.Course _data, bool _new = false)
        {
            InitializeComponent();
            BindingContext = new ViewModels.ModifyCoursePageViewModel(_data, _new);
        }
    }
}