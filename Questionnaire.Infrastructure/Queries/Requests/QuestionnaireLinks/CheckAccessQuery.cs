using MediatR;

namespace Questionnaire.Infrastructure.Queries.Requests.QuestionnaireLinks
{
    public class CheckAccessQuery : IRequest<bool>
    {
        public CheckAccessQuery(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}
