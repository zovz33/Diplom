using AutoMapper;
using Diplom.ASPNET.API.Controllers.Base;
using Diplom.ASPNET.API.Models;
using Diplom.ASPNET.API.Models.Products;
using Diplom.ASPNET.Application.Items.Product.Commands.CreateProduct;
using Diplom.ASPNET.Application.Items.Product.Commands.DeleteProduct;
using Diplom.ASPNET.Application.Items.Product.Commands.UpdateProduct;
using Diplom.ASPNET.Application.Items.Product.Queries.GetProductById;
using Diplom.ASPNET.Application.Lists.Queries.GetProductList;
using Microsoft.AspNetCore.Mvc;

namespace Diplom.ASPNET.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : BaseController
{
    private readonly IMapper _mapper;

    public ProductsController(IMapper mapper)
    {
        _mapper = mapper;
    }
    // -------------------- Create

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateProductDto request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);
        command.Name = request.Name;
        var ProductId = await Mediator.Send(command);
        return Ok(ProductId);
    }

    // -------------------- Update

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateProductDto request)
    {
        var command = _mapper.Map<UpdateProductCommand>(request);
        command.Id = id;
        await Mediator.Send(command);
        return NoContent();
    }

    //[HttpPatch("{id}")]
    //public async Task<IActionResult> Patch(int id, [FromBody] JsonPatchDocument<UpdateProductDto> patchDoc)
    //{
    //    if (patchDoc == null)
    //    {
    //        return BadRequest();
    //    }

    //    // Получить текущий GetProductByIdQueryResult
    //    var query = new GetProductByIdQuery
    //    {
    //        Id = id,
    //    };
    //    var result = await Mediator.Send(query);

    //    if (result == null)
    //    {
    //        throw new NotFoundException(nameof(Product), id);
    //    }

    //    // Преобразовать GetProductByIdQueryResult в UpdateProductDto
    //    var request = _mapper.Map<UpdateProductDto>(result);

    //    // Применить patchDoc к request
    //    patchDoc.ApplyTo(request);

    //    // Сопоставить UpdateProductDto с UpdateProductCommand
    //    var command = _mapper.Map<UpdateProductCommand>(request);
    //    command.Id = id;

    //    await Mediator.Send(command);

    //    return NoContent();
    //}


    // -------------------- Delete

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteProductCommand
        {
            Id = id
        };
        await Mediator.Send(command);
        return NoContent();
    }

    // -------------------- Query

    [HttpGet("List")]
    public async Task<ActionResult<GetProductListQueryResult>> GetAll()
    {
        var query = new GetProductListQuery();
        var result = await Mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetProductByIdQueryResult>> GetById(int id)
    {
        var query = new GetProductByIdQuery
        {
            Id = id
        };
        var result = await Mediator.Send(query);
        return Ok(result);
    }
}