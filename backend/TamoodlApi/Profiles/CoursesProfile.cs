using AutoMapper;
using TamoodlApi.Dtos.Courses;
using TamoodlApi.Models;

namespace TamoodlApi.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<CourseModel, CourseReadDto>();
            CreateMap<CourseCreateDto, CourseModel>();
        }
    }
}