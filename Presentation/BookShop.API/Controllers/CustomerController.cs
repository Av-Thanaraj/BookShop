using log4net;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BookShop.Application.UseCases.Property.Queries.GetAll;
using System.Reflection;
using BookShop.Application.UseCases.Customer.Commands.Create;

namespace BookShop.API.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        public IMediator _mediator;
        
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/v1/Customers")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllQuery()));
        }

        [HttpPost]
        [Route("api/v1/Customers")]
        public async Task<IActionResult> Create(CreateCustomerRequestDto requestDto)
        {
            return Ok(await _mediator.Send(
                new CreateCustomerCommand
                        { requestDto = requestDto }
                    )
                );
        }
    }
}
