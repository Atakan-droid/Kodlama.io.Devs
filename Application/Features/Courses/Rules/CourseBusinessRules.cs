using System.Net.WebSockets;
using Application.Utilities.CrossCuttingConcerns.Exceptions;
using Domain.Repositories;

namespace Application.Features.Courses.Rules;

public class CourseBusinessRules
{
    private readonly ICourseRepository _courseRepository;

    public CourseBusinessRules(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task CourseName_CanNotBe_Duplicated_WhenInserted(string courseName)
    {
        var result = await _courseRepository.GetListAsync(src => src.CourseName == courseName);

        if (result.Any()) throw new BusinessException("Course Name Exist");
    }
}