namespace LexiconUniversity.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string Grade { get; set; }

        // foreign key 
        public int PersonId { get; set; }
        public int CourseId { get; set; }

        // navigation reference
        public Person Person { get; set; }
        public Course Course { get; set; }
    }
}
