using System;

namespace C971_CourseTracker.Models
{
    public class Term : BaseDataModel
    {
        public string title { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string TermDate => $"{startDate:M/dd/yyyy} - {endDate:M/dd/yyyy}";
    }
}
