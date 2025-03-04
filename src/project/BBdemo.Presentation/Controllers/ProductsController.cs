using BBdemo.Application.Features.Products.Commands.Create;
using BBdemo.Application.Features.Products.Commands.Delete;
using BBdemo.Application.Features.Products.Commands.Update;
using BBdemo.Application.Features.Products.Queries.GetAllByCategoryId;
using BBdemo.Application.Features.Products.Queries.GetAllByNameContains;
using BBdemo.Application.Features.Products.Queries.GetById;
using BBdemo.Application.Features.Products.Queries.GetDetails;
using BBdemo.Application.Features.Products.Queries.GetList;
using BBdemo.Application.Features.Products.Queries.GetListPriceRange;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BBdemo.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddCommand command)
        {
            string result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            GetListProductQuery query = new GetListProductQuery();

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetAllDetails()
        {
            var result = await mediator.Send(new GetDetailsProductQuery());

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByıd(int id)
        {
            var result = await mediator.Send(new GetByIdProductQuery() { Id = id });
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            ProductDeleteCommand command = new ProductDeleteCommand { Id = id };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(ProductUpdateCommand updateCommand)
        {
            var result = await mediator.Send(updateCommand);
            return Ok(result);
        }

        [HttpGet("getallbycategoryid")]
        public async Task<IActionResult> GetAllByCategoryId(int categoryId)
        {
            var query = new GetAllByCategoryIdProductQuery { CategoryId = categoryId };

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("getallbypricerange")]
        public async Task<IActionResult> GetAllByPriceRange(double min, double max)
        {
            GetListProductPriceRangeQuery query = new GetListProductPriceRangeQuery() { Min = min, Max = max };

            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("getallbynamecontains")]
        public async Task<IActionResult> GetAllByNameContains(string text)
        {
            GetListProductNameContainQuery query = new() { Text=text};

            var response = await mediator.Send(query);

            return Ok(response);
        }
    }
}
