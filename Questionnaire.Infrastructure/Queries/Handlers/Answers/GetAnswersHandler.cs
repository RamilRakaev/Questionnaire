using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Answers;

namespace Questionnaire.Infrastructure.Queries.Handlers.Answers
{
    public class GetAnswersHandler : IRequestHandler<GetAnswersQuery, Answer[]>
    {
        private readonly IRepository<Answer> _answerRepository;

        public GetAnswersHandler(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public Task<Answer[]> Handle(GetAnswersQuery request, CancellationToken cancellationToken)
        {
            return _answerRepository.GetAllAsNoTracking()
                .Include(answer => answer.User)
                .Include(answer => answer.Structure)
                .ToArrayAsync(cancellationToken);
        }
    }
}
