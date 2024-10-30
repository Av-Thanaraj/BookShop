using BookShop.Application.Common;
using BookShop.Application.Enum;
using BookShop.Application.Mapper;
using BookShop.Application.Repositories;
using BookShop.Application.UseCases.Customer.Queries.GetAllCustomers;
using BookShop.Application.Utility;
using BookShop.Application.Utility.Concrete.Factory;
using BookShop.Infrastructure.Repositories;
using BookShop.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllCustomersQuery).Assembly));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddTransient<IEmailSender>(provider => { return EmailSenderFactory.CreateEmailSender(EmailSenderType.SMTP); });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
