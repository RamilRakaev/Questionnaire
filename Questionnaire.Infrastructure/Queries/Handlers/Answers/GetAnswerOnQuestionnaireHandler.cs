using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Models;
using Questionnaire.Infrastructure.Queries.Requests.Answers;
using System.Text.Json;

namespace Questionnaire.Infrastructure.Queries.Handlers.Answers
{
    public class GetAnswerOnQuestionnaireHandler : IRequestHandler<GetAnswerOnQuestionnaireQuery, List<JsonAnswer>>
    {
        private IRepository<Answer> _answerRepository;

        public GetAnswerOnQuestionnaireHandler(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<List<JsonAnswer>> Handle(GetAnswerOnQuestionnaireQuery request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetAsync(request.AnswerId, cancellationToken);
            return JsonSerializer.Deserialize<List<JsonAnswer>>(answer.Value);
        }
    }
}
