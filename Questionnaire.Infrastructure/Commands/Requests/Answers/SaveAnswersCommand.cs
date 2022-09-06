using MediatR;
using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Commands.Requests.Answers
{
    public class SaveAnswersCommand : IRequest
    {
        public SaveAnswersCommand(List<Answer> answers, int userId, int questionnaireId)
        {
            Answers = answers;
            UserId = userId;
            StructureId = questionnaireId;
        }

        public int UserId { get; private set; }
        public int StructureId { get; private set; }

        public List<Answer> Answers { get; private set; }
    }
}
