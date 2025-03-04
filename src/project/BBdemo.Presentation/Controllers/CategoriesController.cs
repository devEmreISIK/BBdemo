using BBdemo.Application.Features.Categories.Commands.Create;
using BBdemo.Application.Features.Categories.Commands.Delete;
using BBdemo.Application.Features.Categories.Commands.Update;
using BBdemo.Application.Features.Categories.Queries.GetById;
using BBdemo.Application.Features.Categories.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBdemo.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add(CategoryAddCommand command)
    {
        var result = await mediator.Send(command);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        GetListCategoryQuery query = new();

        var result = await mediator.Send(query);

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update(CategoryUpdateCommand updateCommand)
    {
        var result = await mediator.Send(updateCommand);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new CategoryDeleteCommand { Id = id };

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        GetByIdCategoryQuery query = new GetByIdCategoryQuery { Id = id };
        var result = await mediator.Send(query);
        return Ok(result);
    }

}
