using MediatR;
using Questionnaire.Domain.Entities;
using System.Linq.Expressions;

namespace Questionnaire.Infrastructure.Queries.Requests.UniversalQueries
{
    public class GetEntitiesQuery<T> : IRequest<T[]> where T : BaseEntity
    {
        public GetEntitiesQuery()
        {

        }

        public GetEntitiesQuery(Expression<Func<T, bool>> selectionCondition)
        {
            SelectionCondition = selectionCondition;
        }

        public Expression<Func<T, bool>>? SelectionCondition { get; private set; }
    }
}
