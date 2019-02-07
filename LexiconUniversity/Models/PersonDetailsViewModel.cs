using System.Collections.Generic;

namespace LexiconUniversity.Models
{
    public class PersonDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AddressStreet { get; set; }
        public string AddressCity { get; set; }
        public int Attending { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}