namespace C971_CourseTracker.ViewModels
{
    public class ModifyAssessmentPageViewModel : BaseModifyModel
    {
        public Models.Assessment Assessment { get; set; }

        public string[] AssessmentOptions => new string[] { "PA", "OA" };

        public ModifyAssessmentPageViewModel(Models.Assessment _data, bool _new) : base(_new)
        {
            Assessment = _data;
        }
    }
}
