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

namespace BookShop.Application.UseCases.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersResponseDto>>
    {
    }
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersResponseDto>>
    {
        public IGenericRepository<BookShop.Domain.Entities.User> _genericRepository;
        public IMapper _mapper;
        private IEmailSender _emailSender;

        private static readonly ILog _logger = LogManager.GetLogger(typeof(GetAllUsersQuery));
        public GetAllUsersQueryHandler(IGenericRepository<BookShop.Domain.Entities.User> genericRepository, IMapper mapper, IEmailSender emailSender)
        {
            _genericRepository = genericRepository;
            _mapper = mapper;
            _emailSender = emailSender;
        }
        public async Task<List<GetAllUsersResponseDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.Debug($"Get All User Start");
                var result = await _genericRepository.GetAllAsync();
                _logger.Debug($"Get All User End");
                return _mapper.Map<List<GetAllUsersResponseDto>>(result);
            }
            catch (Exception ex)
            {
                _logger.Error($"Get all User exception fired: Exception {ex}");
                throw new Exception();
            }
        }
    }
}
