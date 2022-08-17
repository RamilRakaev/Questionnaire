using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.UniversalCommands
{
    public class RemoveEntityCommand<T> : IRequest where T : BaseEntity
    {
        public RemoveEntityCommand(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; private set; }
    }
}
