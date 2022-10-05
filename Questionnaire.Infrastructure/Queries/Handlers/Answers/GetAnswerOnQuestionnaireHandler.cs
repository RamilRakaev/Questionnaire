using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Models;
using Questionnaire.Infrastructure.Queries.Requests.Answers;
using System.Text.Json;

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

            return ConvertToNestedDictionary(dictionary);
        }

        private List<PropertyAnswer> ConvertToNestedDictionary(Dictionary<string, string> dictionary)
        {
            List<PropertyAnswer> propertyAnswers = new();

            foreach (var propertyAnswerInJson in dictionary)
            {
                //var nestedDictionary = JsonSerializer.<Dictionary<string, string>>(propertyAnswerInJson.Value);
                if (propertyAnswerInJson.Value is Dictionary<string, string>)
                {
                    propertyAnswers.AddRange(ConvertToNestedDictionary(nestedDictionary));
                }
                else
                {
                    PropertyAnswer propertyAnswer = new()
                    {
                        Property = new()
                        {
                            JsonName = propertyAnswerInJson.Key,
                        },
                        Answer = new()
                        {
                            Value = propertyAnswerInJson.Value?.ToString(),
                        },
                    };
                    propertyAnswers.Add(propertyAnswer);
                }
            }

            return propertyAnswers;
        }
    }
}
