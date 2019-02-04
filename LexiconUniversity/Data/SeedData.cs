using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LexiconUniversity.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var options = serviceProvider.GetRequiredService<DbContextOptions<LexiconUniversityContext>>();
            using (var context = new LexiconUniversityContext(options))
            {
                if (context.Person.Any())
                {
                    context.Person.RemoveRange(context.Person);
                    context.Course.RemoveRange(context.Course);
                    context.Enrollment.RemoveRange(context.Enrollment);
                }


                // Let's seed!
                var people = new List<Person>();
                for (int i = 0; i < 100; i++)
                {
                    string name = Faker.Name.FullName();
                    var person = new Person
                    {
                        Name = name,
                        Email = Faker.Internet.Email(name),
                        Address = new Address
                        {
                            Street = Faker.Address.StreetAddress(),
                            City = Faker.Address.City()
                        }
                    };
                    people.Add(person);
                }
                context.Person.AddRange(people);

                var textInfo = new CultureInfo("en-us", false).TextInfo;
                var courses = new List<Course>();
                for (int i = 0; i < 10; i++)
                {
                    var course = new Course
                    {
                        Title = textInfo.ToTitleCase(Faker.Company.BS())
                    };
                    courses.Add(course);
                }
                context.Course.AddRange(courses);
                context.SaveChanges();

                var enrollments = new List<Enrollment>();
                foreach (var person in people)
                {
                    foreach (var course in courses)
                    {
                        if (Faker.RandomNumber.Next(5) == 0) {
                            var enrollment = new Enrollment
                            {
                                Course = course,
                                Person = person,
                            };
                            enrollments.Add(enrollment);
                        }
                    }
                }
                context.Enrollment.AddRange(enrollments);
                context.SaveChanges();
            }
        }
    }
}
