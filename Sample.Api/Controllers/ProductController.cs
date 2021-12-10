using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Commands.Products.Add;
using Sample.Domain.Product;
using Sample.Queries.Products.Get;
using Sample.Queries.Products.GetAll;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {

        public ProductController(IMediator mediator):base(mediator)
        {
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Product>))]
        public async Task<IActionResult> Get()
        {
            var products = await Mediator.Send(new GetAllProductQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Produces(typeof(IEnumerable<Product>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetProductQuery(id);
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] AddProductCommand command)
        {
            //TODO: Depending on needs, validation can be done either only by Domain object or we can use MediatR pipeline
            CheckIfNull(command);
            var id = await Mediator.Send(command);
            return Created($"api/product/{id}", id);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, AddProductCommand command)
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
