using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyTermPage : ContentPage
    {
        public ModifyTermPage(Models.Term _data, bool _new = false)
        {
            InitializeComponent();
            BindingContext = new ViewModels.ModifyTermPageViewModel(_data, _new);
        }
    }
}