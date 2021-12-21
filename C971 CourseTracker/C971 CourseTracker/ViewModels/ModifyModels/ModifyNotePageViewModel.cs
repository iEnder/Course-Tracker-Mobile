using Xamarin.Essentials;
using Xamarin.Forms;

namespace C971_CourseTracker.ViewModels
{
    public class ModifyNotePageViewModel : BaseModifyModel
    {
        public Models.Note Note { get; set; }
        public Command ShareCommand { get; }

        private async void OnShare()
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = Note.content,
                Title = "Note"
            });
        }

        public ModifyNotePageViewModel(Models.Note _note, bool _new) : base(_new)
        {
            ShareCommand = new Command(OnShare);
            Note = _note;
        }
    }
}
