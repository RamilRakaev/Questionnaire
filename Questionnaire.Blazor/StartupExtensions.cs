using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Questionnaire.Domain.Entities;
using System;
using System.Linq;

namespace Questionnaire.Blazor
{
    public static class StartupExtensions
    {
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
                var iRequestHandlerType = typeof(IRequestHandler<>).MakeGenericType(currentCommandType);
                var currentHandlerType = handlerType.MakeGenericType(entityType);

                services.AddTransient(iRequestHandlerType, currentHandlerType);
            }
        }

    }
}
