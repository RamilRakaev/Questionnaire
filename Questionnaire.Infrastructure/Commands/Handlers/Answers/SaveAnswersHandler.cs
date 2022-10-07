using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Answers;
using Questionnaire.Infrastructure.Models;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Questionnaire.Infrastructure.Commands.Handlers.Answers
{
    public class SaveAnswersHandler : IRequestHandler<SaveAnswersCommand>
    {
        private readonly IRepository<Answer> _answerRepository;

        public SaveAnswersHandler(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(SaveAnswersCommand request, CancellationToken cancellationToken)
        {
            if (request.PropertyAnswers.Count > 0)
            {
                JsonSerializerOptions options = new()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                var answersInJson = JsonSerializer.Serialize(CreateObjectForJson(request.PropertyAnswers), options);

                Answer answerEntity = new()
                {
                    Value = answersInJson,
                    StructureId = request.StructureId,
                    UserId = request.UserId,
                };

                await _answerRepository.AddAsync(answerEntity, cancellationToken);

                return Unit.Value;
            }

            throw new Exception("Dictionary of questions and answers is empty");
        }

        private List<JsonAnswer> CreateObjectForJson(List<PropertyAnswer> propertyAnswers)
        {
            List<JsonAnswer> answers = new();

            foreach (var propertyAnswer in propertyAnswers)
            {
                JsonAnswer answer = new()
                {
                    Name = propertyAnswer.Property.JsonName,
                    Value = propertyAnswer.Answer.Value,
                };

                answers.Add(answer);

                if (propertyAnswer.PropertyAnswers != null)
                {
                    answer.Answers = CreateObjectForJson(propertyAnswer.PropertyAnswers);
                }
            }

            return answers;
        }
    }
}
