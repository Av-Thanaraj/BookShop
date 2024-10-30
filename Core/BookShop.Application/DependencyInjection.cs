using Microsoft.Extensions.DependencyInjection;
using BookShop.Application.Common;
using BookShop.Application.Mapper;
using BookShop.Application.UseCases.Property.Queries.GetAll;
using BookShop.Application.Utility;
using BookShop.Application.Utility.Concrete.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllQueryHandler).Assembly));
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            services.AddTransient<IEmailSender>(provider => { return EmailSenderFactory.CreateEmailSender(Enum.EmailSenderType.SMTP); });

            return services;
        }
    }
}
