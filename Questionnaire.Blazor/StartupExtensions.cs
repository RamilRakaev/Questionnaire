using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Domain.Entities;
using System;
using System.Linq;

namespace Questionnaire.Blazor
{
    public static class StartupExtensions
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(configure =>
            {
                var profiles = typeof(Startup).Assembly.GetTypes()
                    .Where(type => type.BaseType == typeof(Profile));

                foreach (var mapperType in profiles)
                {
                    configure.AddProfile(mapperType);
                }
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void AddUniversalHandler<Entity>(this IServiceCollection services, Type commandType, Type handlerType)
        {
            AddUniversalHandler<Entity>(services, commandType, handlerType, entityType => entityType);
        }

        public static void AddUniversalHandler<Entity>(this IServiceCollection services, Type commandType, Type handlerType, Func<Type, Type> handlerResult)
        {
            var types = typeof(BaseEntity)
                .Assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(Entity));

            foreach (var entityType in types)
            {
                var currentQueryType = commandType.MakeGenericType(entityType);
                var iRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(currentQueryType, handlerResult(entityType));
                var currentHandlerType = handlerType.MakeGenericType(entityType);

                services.AddTransient(iRequestHandlerType, currentHandlerType);
            }
        }
    }
}
