using Application.Features.CourseTech.Dtos;
using Domain.Entities;

namespace Application.Features.Courses.Dtos;

public class CourseDto
{
    public string CourseName { get; set; }
    public double Price { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public List<CourseTechList> CourseTechs { get; set; }
}