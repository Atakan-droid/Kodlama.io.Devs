using Application.Features.Courses.Commands.CreateCourse;
using Application.Features.Courses.Commands.DeleteCourse;
using Application.Features.Courses.Commands.UpdateCourse;
using Application.Features.Courses.Queries.GetCourseByIdQuery.cs;
using Application.Features.Courses.Queries.GetListCourse.cs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CourseController : BaseController
{
    [HttpGet("getlist")]
    public async Task<IActionResult> GetListAsync(GetListCourseQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    [HttpGet("getById")]
    public async Task<IActionResult> GetByIdAsync(GetCourseByIdQuery query)
    {
        var result = await Mediator.Send(query);
        return Ok(result);
    }
    [HttpPost("add")]
    public async Task<IActionResult> AddAsync([FromBody] CreateCourseCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCourseCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteAsync([FromBody] DeleteCourseCommand command)
    {
        var result = await Mediator.Send(command);
        return Ok(result);
    }
}