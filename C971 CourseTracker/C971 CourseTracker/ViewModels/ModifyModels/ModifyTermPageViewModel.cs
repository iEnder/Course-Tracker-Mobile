namespace C971_CourseTracker.ViewModels
{
    public class ModifyTermPageViewModel : BaseModifyModel
    {
        public Models.Term Term { get; set; }

        public ModifyTermPageViewModel(Models.Term _data, bool _new) : base(_new)
        {
            Term = _data;
        }
    }
}
