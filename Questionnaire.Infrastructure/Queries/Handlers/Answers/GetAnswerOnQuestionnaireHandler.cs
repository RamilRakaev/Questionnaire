using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Models;
using Questionnaire.Infrastructure.Queries.Requests.Answers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Questionnaire.Infrastructure.Queries.Handlers.Answers
{
    public class GetAnswerOnQuestionnaireHandler : IRequestHandler<GetAnswerOnQuestionnaireQuery, List<PropertyAnswer>>
    {
        private IRepository<Answer> _answerRepository;

        public GetAnswerOnQuestionnaireHandler(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<List<PropertyAnswer>> Handle(GetAnswerOnQuestionnaireQuery request, CancellationToken cancellationToken)
        {
            var answer = await _answerRepository.GetAsync(request.AnswerId, cancellationToken);

            var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(answer.Value);
            List<PropertyAnswer> propertyAnswers = new();
            foreach (var propertyAnswerInJson in dictionary)
            {
                PropertyAnswer propertyAnswer = new()
                {
                    Property = new()
                    {
                        q
                    },
                    Answer = new()
                    {
                        Value = propertyAnswerInJson.Value.ToString(),
                    },
                };
                if (propertyAnswerInJson.Value is Dictionary<string, object>)
                {

                }
            }
        }
    }
}
