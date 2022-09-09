using MediatR;

namespace Questionnaire.Infrastructure.Queries.Requests.Structures
{
    public class CheckDisplayNameUniquenessQuery : IRequest<bool>
    {
        public CheckDisplayNameUniquenessQuery(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; private set; }
    }
}
