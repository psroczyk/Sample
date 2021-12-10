using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.Domain.Base;

namespace Sample.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly IMediator Mediator;

        public BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected void CheckIfNull(object model)
        {
            if (model == null)
            {
                throw new DomainException("You must provide request body"); //TODO: create ApiException and change this to it
            }
        }
    }
}
