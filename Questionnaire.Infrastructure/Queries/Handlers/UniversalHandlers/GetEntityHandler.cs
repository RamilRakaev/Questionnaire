using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.UniversalQueries;

namespace Questionnaire.Infrastructure.Queries.Handlers.UniversalHandlers
{
    public class GetEntityHandler<T> : IRequestHandler<GetEntityQuery<T>, T> where T : BaseEntity
    {
        private readonly IRepository<T> _entityRepository;

        public GetEntityHandler(IRepository<T> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public Task<T> Handle(GetEntityQuery<T> request, CancellationToken cancellationToken)
        {
            return _entityRepository.GetAsync(request.Id, cancellationToken);
        }
    }
}
