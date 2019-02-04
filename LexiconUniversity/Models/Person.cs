using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconUniversity.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // navigation reference???
        public Address Address { get; set; }

        // navigation collection???
        [NotMapped]
        public ICollection<string> PhoneNr { get; set; }

        // navigation collection
        public ICollection<Enrollment> Enrollments { get; set; }
    }

    [Owned]
    public class Address
    {
        public string Street { get; set; }
        public string City { get; set; }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // navigation collection
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}

