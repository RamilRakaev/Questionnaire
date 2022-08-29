﻿using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Answers;
using System.Text.Json;

namespace Questionnaire.Infrastructure.Commands.Handlers.Answers
{
    public class CreateAnswersHandler : IRequestHandler<CreateAnswersCommand>
    {
        private readonly IRepository<Answer> _answerRepository;

        public CreateAnswersHandler(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(CreateAnswersCommand request, CancellationToken cancellationToken)
        {
            if (request.QuestionsAnswers.Count > 0)
            {
                var questionsAnswers = request.QuestionsAnswers.ToDictionary(pair => pair.Key.JsonName, pair => pair.Value.Value);
                var answersInJson = JsonSerializer.Serialize(questionsAnswers);

                Answer answerEntity = new()
                {
                    QuestionnaireId = request.QuestionsAnswers.Keys.FirstOrDefault().StructureId,
                    Value = answersInJson,
                    UserId = request.UserId,
                };

                await _answerRepository.AddAsync(answerEntity, cancellationToken);

                return Unit.Value;
            }

            throw new Exception("Dictionary of questions and answers is empty");
        }
    }
}
