using BookShop.Application.UseCases.User.Commands.CreateUser;
using BookShop.Application.UseCases.User.Queries.GetAllUsers;
using log4net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace BookShop.API.Controllers
{
    public class UserController : Controller
    {
        public readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        public IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/Users")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        [HttpPost]
        [Route("api/v1/Users")]
        public async Task<IActionResult> Create(CreateUserRequestDto requestDto)
        {
            return Ok(await _mediator.Send(
                new CreateUserCommand
                { requestDto = requestDto }
                    )
                );
        }
    }
}
