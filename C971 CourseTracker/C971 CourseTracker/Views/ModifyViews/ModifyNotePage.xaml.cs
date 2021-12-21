
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace C971_CourseTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyNotePage : ContentPage
    {
        public ModifyNotePage(Models.Note _note, bool _new = false)
        {
            InitializeComponent();
            BindingContext = new ViewModels.ModifyNotePageViewModel(_note, _new);
        }
    }
}