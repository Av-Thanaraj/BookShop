using AutoMapper;
using BookShop.Application.Repositories;
using BookShop.Application.UseCases.Customer.Commands.CreateCustomer;
using BookShop.Application.Utility;
using log4net;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<bool>
    {
        public CreateUserRequestDto requestDto { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        public IGenericRepository<BookShop.Domain.Entities.User> _genericRepository;
        public IMapper _mapper;
        private IEmailSender _emailSender;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(CreateUserCommand));
        public CreateUserCommandHandler(IGenericRepository<BookShop.Domain.Entities.User> genericRepository, IMapper mapper, IEmailSender emailSender)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Create User Start");
                var user = _mapper.Map<BookShop.Domain.Entities.User>(request.requestDto);
                var result = await _genericRepository.AddAsync(user);
                _logger.Debug($"Create User End");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error($"Create User exception fired: Exception {ex}");
                throw new Exception();
            }
        }
    }
}
