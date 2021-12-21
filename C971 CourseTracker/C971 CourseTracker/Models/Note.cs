namespace C971_CourseTracker.Models
{
    public class Note : BaseDataModel
    {
        public string content { get; set; }
        public int courseId { get; set; }
    }
}
