using Application.Features.Courses.Dtos;
using Domain.Entities;

namespace Application.Features.CourseTech.Dtos;

public class CreateCourseTechDto
{
    public string Name { get; set; }
    public CourseDto Course { get; set; }
}