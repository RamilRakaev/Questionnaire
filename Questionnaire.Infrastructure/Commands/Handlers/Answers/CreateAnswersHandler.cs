using MediatR;
using Questionnaire.Domain.Entities;
using Questionnaire.Domain.Interfaces;
using Questionnaire.Infrastructure.Commands.Requests.Answers;

namespace Questionnaire.Infrastructure.Commands.Handlers.Answers
{
    public class CreateAnswersHandler : IRequestHandler<CreateAnswersCommand>
    {
        private readonly IRepository<AnswerEntity> _answerRepository;

        public CreateAnswersHandler(IRepository<AnswerEntity> answerRepository)
        {
            _answerRepository = answerRepository;
        }
        public async Task<Unit> Handle(CreateAnswersCommand request, CancellationToken cancellationToken)
        {
            await _answerRepository.AddRangeAsync(request.Answers, cancellationToken);
            return Unit.Value;
        }
    }
}
