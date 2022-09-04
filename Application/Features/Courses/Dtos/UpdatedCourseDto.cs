namespace Application.Features.Courses.Dtos;

public class UpdatedCourseDto
{
    public string CourseName { get; set; }
    public double Price { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}