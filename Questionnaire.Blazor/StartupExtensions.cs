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

        public static void ConfigureEntitiesQueryHandlers<Entity>(this IServiceCollection services, Type commandType, Type handlerType)
        {
            var types = typeof(BaseEntity)
                .Assembly
                .GetTypes()
                .Where(t => t.BaseType == (typeof(Entity)));

            foreach (var entityType in types)
            {
                var arrayType = Array.CreateInstance(entityType, 0).GetType();

                var currentQueryType = commandType.MakeGenericType(entityType);
                var iRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(currentQueryType, arrayType);
                var currentHandlerType = handlerType.MakeGenericType(entityType);

                services.AddTransient(iRequestHandlerType, currentHandlerType);
            }
        }

        public static void ConfigureEntityQueryHandlers<Entity>(this IServiceCollection services, Type commandType, Type handlerType)
        {
            var types = typeof(BaseEntity)
                .Assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(Entity));

            foreach (var entityType in types)
            {
                var currentCommandType = commandType.MakeGenericType(entityType);
                var iRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(currentCommandType, entityType);
                var currentHandlerType = handlerType.MakeGenericType(entityType);

                services.AddTransient(iRequestHandlerType, currentHandlerType);
            }
        }

        public static void ConfigureEntityCommandHandlers<Entity>(this IServiceCollection services, Type commandType, Type handlerType)
        {
            var types = typeof(BaseEntity)
                .Assembly
                .GetTypes()
                .Where(t => t.BaseType == typeof(Entity));

            foreach (var entityType in types)
            {
                var currentCommandType = commandType.MakeGenericType(entityType);
                var iRequestHandlerType = typeof(IRequestHandler<,>).MakeGenericType(currentCommandType, typeof(Unit));
                var currentHandlerType = handlerType.MakeGenericType(entityType);

                services.AddTransient(iRequestHandlerType, currentHandlerType);
            }
        }
    }
}
