using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Answers
{
    public class CreateAnswersCommand : IRequest
    {
        public CreateAnswersCommand(IEnumerable<AnswerEntity> answers)
        {
            Answers = answers;
        }

        public IEnumerable<AnswerEntity> Answers { get; private set; }
    }
}
