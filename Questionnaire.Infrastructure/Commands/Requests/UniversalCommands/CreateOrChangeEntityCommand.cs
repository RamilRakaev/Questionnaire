using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.UniversalCommands
{
    public class CreateOrChangeEntityCommand<T> : IRequest where T : BaseEntity
    {
        public CreateOrChangeEntityCommand(T entity)
        {
            Entity = entity;
        }

        public T Entity { get; set; }
    }
}
