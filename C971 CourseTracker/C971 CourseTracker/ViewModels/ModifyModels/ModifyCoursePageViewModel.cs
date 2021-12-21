namespace C971_CourseTracker.ViewModels
{
    public class ModifyCoursePageViewModel : BaseModifyModel
    {
        public Models.Course Course { get; set; }

        public string[] StatusOptions => new string[] { "in progress", "completed", "dropped", "plan to take" };

        public ModifyCoursePageViewModel(Models.Course _data, bool _new) : base(_new)
        {
            Course = _data;
        }
    }
}
