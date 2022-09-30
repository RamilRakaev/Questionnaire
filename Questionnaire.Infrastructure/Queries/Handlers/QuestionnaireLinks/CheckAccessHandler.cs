using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.QuestionnaireLinks;

namespace Questionnaire.Infrastructure.Queries.Handlers.QuestionnaireLinks
{
    public class CheckAccessHandler : IRequestHandler<CheckAccessQuery, bool>
    {
        private readonly IRepository<QuestionnaireLink> _questionnaireLinkRepository;

        public CheckAccessHandler(IRepository<QuestionnaireLink> questionnaireLinkRepository)
        {
            _questionnaireLinkRepository = questionnaireLinkRepository;
        }

        public Task<bool> Handle(CheckAccessQuery request, CancellationToken cancellationToken)
        {
            return _questionnaireLinkRepository.GetAllAsNoTracking()
                .AnyAsync(questionnaireLink => questionnaireLink.Token == request.Token, cancellationToken);
        }
    }
}
