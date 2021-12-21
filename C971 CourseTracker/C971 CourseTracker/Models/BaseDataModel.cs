using SQLite;

namespace C971_CourseTracker.Models
{
    public class BaseDataModel
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
    }
}
