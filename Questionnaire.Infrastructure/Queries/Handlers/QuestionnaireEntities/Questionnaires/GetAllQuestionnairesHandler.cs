using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.QuestionnaireEntities.Questionnaires;

namespace Questionnaire.Infrastructure.Queries.Handlers.QuestionnaireEntities.Questionnaires
{
    public class GetAllQuestionnairesHandler : IRequestHandler<GetAllQuestionnairesQuery, QuestionnaireEntity[]>
    {
        private readonly IRepository<QuestionnaireEntity> _questionnaireRepository;

        public GetAllQuestionnairesHandler(IRepository<QuestionnaireEntity> questionnaireRepository)
        {
            _questionnaireRepository = questionnaireRepository;
        }

        public Task<QuestionnaireEntity[]> Handle(GetAllQuestionnairesQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_questionnaireRepository.GetAllAsNoTracking().ToArray());
        }
    }
}
