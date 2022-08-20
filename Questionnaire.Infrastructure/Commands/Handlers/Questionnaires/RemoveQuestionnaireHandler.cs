using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Questionnaires;

namespace Questionnaire.Infrastructure.Commands.Handlers.Questionnaires
{
    public class RemoveQuestionnaireHandler : IRequestHandler<RemoveQuestionnaireCommand>
    {
        private readonly IRepository<QuestionnaireEntity> _questionnaireRepository;
        private readonly IRepository<PropertyEntity> _questionRepository;
        private readonly IRepository<PropertyEntity> _answerRepository;

        public RemoveQuestionnaireHandler(IRepository<QuestionnaireEntity> questionnaireRepository, IRepository<PropertyEntity> questionRepository,
            IRepository<PropertyEntity> answerRepository)
        {
            _questionnaireRepository = questionnaireRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(RemoveQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var questionnaire = await _questionnaireRepository.GetAllAsNoTracking()
                .Where(questionnaire => questionnaire.Id == request.QuestionnaireId)
                .FirstOrDefaultAsync(cancellationToken);
            if (questionnaire == null)
            {
                throw new NullReferenceException("Questionnaire was not found in the database");
            }

            var ansers = _answerRepository.GetAllAsNoTracking().Where(answer => answer.QuestionnaireId == request.QuestionnaireId);
            await _answerRepository.RemoveRangeAsync(ansers, cancellationToken);

            var questions = _questionRepository.GetAllAsNoTracking().Where(question => question.QuestionnaireId == request.QuestionnaireId);
            await _questionRepository.RemoveRangeAsync(questions, cancellationToken);

            await _questionnaireRepository.RemoveAsync(questionnaire, cancellationToken);

            return Unit.Value;
        }
    }
}
