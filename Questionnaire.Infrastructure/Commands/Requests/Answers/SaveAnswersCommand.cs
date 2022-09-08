using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Answers
{
    public class SaveAnswersCommand : IRequest
    {
        public SaveAnswersCommand(Dictionary<Answer, Property> answers, int userId)
        {
            QuestionsAnswers = answers;
            UserId = userId;
        }

        public int UserId { get; private set; }

        public Dictionary<Answer, Property> QuestionsAnswers { get; private set; }
    }
}
