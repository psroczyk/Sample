using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Api.Requests;
using Sample.Commands.Products.Add;
using Sample.Domain.Product;
using Sample.Queries.Products.Get;
using Sample.Queries.Products.GetAll;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Produces(typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProductQuery(id);
            return Ok(await _mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AddProductRequest request)
        {
            var id = await _mediator.Send(new AddProductCommand(request.Name));
            return Created($"api/products/{id}", id);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, AddProductRequest request)
        {
            //TODO
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            //TODO
        }
    }
}
