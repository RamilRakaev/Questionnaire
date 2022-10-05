using MediatR;
using Microsoft.EntityFrameworkCore;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Queries.Requests.Answers;

namespace Questionnaire.Infrastructure.Queries.Handlers.Answers
{
    public class GetAllAnswersHandler : IRequestHandler<GetAllAnswersQuery, List<Answer>>
    {
        private readonly IRepository<Answer> _answerRepository;

        public GetAllAnswersHandler(IRepository<Answer> answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public Task<List<Answer>> Handle(GetAllAnswersQuery request, CancellationToken cancellationToken)
        {
            return _answerRepository.GetAllAsNoTracking()
                .Include(answer => answer.User)
                .Include(answer => answer.Structure)
                .ToListAsync(cancellationToken);
        }
    }
}
