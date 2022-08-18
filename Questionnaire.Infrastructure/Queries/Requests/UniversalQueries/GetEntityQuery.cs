using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Queries.Requests.UniversalQueries
{
    public class GetEntityQuery<T> : IRequest<T> where T : BaseEntity
    {
        public GetEntityQuery(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
