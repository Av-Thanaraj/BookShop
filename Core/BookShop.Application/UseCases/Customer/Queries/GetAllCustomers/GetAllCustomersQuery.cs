using AutoMapper;
using log4net;
using MediatR;
using BookShop.Application.Repositories;
using BookShop.Application.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application.UseCases.Customer.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IRequest<List<GetAllCustomersResponseDto>>
    {
    }
    public class GetAllQueryHandler : IRequestHandler<GetAllCustomersQuery, List<GetAllCustomersResponseDto>>
    {
        protected readonly IGenericRepository<BookShop.Domain.Entities.Customer> _genericRepository;
        public IMapper _mapper;
        private IEmailSender _emailSender;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(GetAllCustomersQuery));
        public GetAllQueryHandler(IGenericRepository<BookShop.Domain.Entities.Customer> genericRepository, IMapper mapper, IEmailSender emailSender)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<List<GetAllCustomersResponseDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Get All Customer Start");
                var result = await _genericRepository.GetAllAsync();
                _logger.Debug($"Get All Customer End");
                return _mapper.Map<List<GetAllCustomersResponseDto>>(result);
            }
            catch (Exception ex) {
                _logger.Error($"Get all Customer exception fired: Exception {ex}");
                throw new Exception();
            }
        }
    }
}
