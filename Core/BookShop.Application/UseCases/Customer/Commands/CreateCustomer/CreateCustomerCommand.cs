using AutoMapper;
using BookShop.Application.Repositories;
using BookShop.Application.Utility;
using log4net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.UseCases.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<bool>
    {
        public CreateCustomerRequestDto requestDto { get; set; }
    }
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, bool>
    {
        protected readonly IGenericRepository<BookShop.Domain.Entities.Customer> _genericRepository;
        public IMapper _mapper;
        private IEmailSender _emailSender;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(CreateCustomerCommand));
        public CreateCustomerCommandHandler(IGenericRepository<BookShop.Domain.Entities.Customer> genericRepository, IMapper mapper, IEmailSender emailSender)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<bool> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Create Customer Start");
                var customer = _mapper.Map<BookShop.Domain.Entities.Customer>(request.requestDto);
                var result = await _genericRepository.AddAsync(customer);
                _logger.Debug($"Create Customer End");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Create Customer exception fired: Exception {ex}");
                throw new Exception();
            }
        }
    }
}
