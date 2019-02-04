using AutoMapper;
using LexiconUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconUniversity.Models
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Person, PersonDetailsViewModel>()
                .ForMember(
                    dest => dest.Courses,
                    from => from.MapFrom(p => p.Enrollments.Select(e => e.Course).ToList()));
        }
    }
}
