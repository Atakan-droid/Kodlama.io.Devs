using Application.Features.Courses.Commands.CreateCourse;
using Application.Features.Courses.Commands.UpdateCourse;
using Application.Features.Courses.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Courses.Profiles;

public class CourseAutoMapperProfile:Profile
{
    public CourseAutoMapperProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<Course,CreatedCourseDto>();
        CreateMap<CreateCourseCommand, Course>();
        CreateMap<UpdateCourseCommand, Course>();
        CreateMap<Course,UpdatedCourseDto>();
        CreateMap<Course, CourseListDto>().ReverseMap();
        
    }
}