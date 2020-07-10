using AutoMapper;
using CaWorkshop.Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace CaWorkshop.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));
            
            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(LoggingBehaviour<>));

            services.AddTransient(typeof(IPipelineBehavior<,>),
                typeof(PerformanceBehaviour<,>));

            //services.AddAllRequestValidators();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
