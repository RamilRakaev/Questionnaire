using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.UniversalCommands
{
    public class RemoveEntityCommand<T> : IRequest where T : BaseEntity
    {
        public RemoveEntityCommand(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; private set; }
    }
}
