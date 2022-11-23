using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Market.Application.Common.Behaviors;
using Market.Application.Security;
using Microsoft.Extensions.Configuration;
using Market.Application.Repositories.ImageRepository;

namespace Market.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection service, IConfiguration configuration)
        {
            service.AddSingleton<IAuth, Auth>();
            service.AddSingleton<IImageRepository, ImageRepository>();

            service.AddMediatR(Assembly.GetExecutingAssembly());

            service
                .AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            service.AddAuthSettings(configuration);

            return service;
        }
    }
}
