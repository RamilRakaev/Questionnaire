using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.UniversalQueries;

namespace Questionnaire.Infrastructure.Queries.Handlers.UniversalHandlers
{
    public class GetEntitiesHandler<T> : IRequestHandler<GetEntitiesQuery<T>, T[]> where T : BaseEntity
    {
        private readonly IRepository<T> _entityRepository;

        public GetEntitiesHandler(IRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<T[]> Handle(GetEntitiesQuery<T> request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_entityRepository.GetAllAsNoTracking().ToArray());
        }
    }
}
