using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Answers
{
    public class CreateAnswersCommand : IRequest
    {
        public CreateAnswersCommand(Dictionary<Property, Answer> answers, int userId)
        {
            QuestionsAnswers = answers;
            UserId = userId;
        }

        public int UserId { get; private set; }

        public Dictionary<Property, Answer> QuestionsAnswers { get; private set; }
    }
}
