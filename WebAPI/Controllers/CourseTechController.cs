using Application.Features.CourseTech.Commands.CreateCourseTech;
using Application.Features.CourseTech.Commands.DeleteCourseTech;
using Application.Features.CourseTech.Commands.UpdateCourseTech;
using Application.Features.CourseTech.Queries.GetCourseTechById;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class CourseTechController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> CreateCourseTech(CreateCourseTechCommand createCourseTechCommand)
    {
        var courseTech = await Mediator.Send(createCourseTechCommand);
        return Ok(courseTech);
    }
    [HttpPost("update")]
    public async Task<IActionResult> UpdateCourseTech(UpdateCourseTechCommand command)
    {
        var courseTech = await Mediator.Send(command);
        return Ok(courseTech);
    }
    [HttpPost("delete")]
    public async Task<IActionResult> DeleteCourseTech(DeleteCourseTechCommand command)
    {
        var courseTech = await Mediator.Send(command);
        return Ok(courseTech);
    }
    [HttpGet("get")]
    public async Task<IActionResult> getCourseTech(GetCourseTechByIdQueries query)
    {
        var courseTech = await Mediator.Send(query);
        return Ok(courseTech);
    }
   

}