using System.Windows.Input;
using Xamarin.Forms;


namespace C971_CourseTracker.ViewModels
{
    public class EvaluatorPageViewModel : BaseModel
    {
        public ICommand LoadDataCommand { get; set; }

        public EvaluatorPageViewModel()
        {
            LoadDataCommand = new Command(OnLoadClick);
        }

        private void OnLoadClick()
        {
            CourseDB.LoadSampleData();
        }
    }
}
