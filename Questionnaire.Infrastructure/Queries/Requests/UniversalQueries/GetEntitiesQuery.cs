using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.UniversalQueries
{
    public class GetEntitiesQuery<T> : IRequest<T[]> where T : BaseEntity
    {
    }
}
