using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LexiconUniversity.Models;

namespace LexiconUniversity.Models
{
    public class LexiconUniversityContext : DbContext
    {
        public LexiconUniversityContext (DbContextOptions<LexiconUniversityContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
    }
}
