using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchWithCQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private ISender _mediator;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>(); //if null get instance of that service


    }
}
