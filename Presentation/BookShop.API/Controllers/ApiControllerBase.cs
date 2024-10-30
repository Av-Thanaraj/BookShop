using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.API.Controllers
{
    public class ApiControllerBase : Controller
    {
        private ISender _mediator;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
    }
}
