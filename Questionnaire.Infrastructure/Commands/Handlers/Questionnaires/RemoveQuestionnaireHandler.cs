using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Questionnaires;

namespace Questionnaire.Infrastructure.Commands.Handlers.Questionnaires
{
    public class RemoveQuestionnaireHandler : IRequestHandler<RemoveQuestionnaireCommand>
    {
        private readonly IRepository<Structure> _questionnaireRepository;
        private readonly IRepository<Property> _questionRepository;
        private readonly IRepository<Property> _answerRepository;

        public RemoveQuestionnaireHandler(IRepository<Structure> questionnaireRepository, IRepository<Property> questionRepository,
            IRepository<Property> answerRepository)
        {
            _questionnaireRepository = questionnaireRepository;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public async Task<Unit> Handle(RemoveQuestionnaireCommand request, CancellationToken cancellationToken)
        {
            var questionnaire = await _questionnaireRepository.GetAllAsNoTracking()
                .Where(questionnaire => questionnaire.Id == request.StructureId)
                .FirstOrDefaultAsync(cancellationToken);
            if (questionnaire == null)
            {
                throw new NullReferenceException("Questionnaire no found in DB");
            }

            var ansers = _answerRepository.GetAllAsNoTracking().Where(answer => answer.StructureId == request.StructureId);
            await _answerRepository.RemoveRangeAsync(ansers, cancellationToken);

            var questions = _questionRepository.GetAllAsNoTracking().Where(question => question.StructureId == request.StructureId);
            await _questionRepository.RemoveRangeAsync(questions, cancellationToken);

            await _questionnaireRepository.RemoveAsync(questionnaire, cancellationToken);

            return Unit.Value;
        }
    }
}
