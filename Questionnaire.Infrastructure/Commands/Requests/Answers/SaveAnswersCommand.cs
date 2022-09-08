using MediatR;
using Questionnaire.Infrastructure.Models;

namespace Questionnaire.Infrastructure.Commands.Requests.Answers
{
    public class SaveAnswersCommand : IRequest
    {
        public SaveAnswersCommand(List<PropertyAnswer> propertyAnswers, int structureId, int userId)
        {
            PropertyAnswers = propertyAnswers;
            StructureId = structureId;
            UserId = userId;
        }

        public List<PropertyAnswer> PropertyAnswers { get; private set; }

        public int StructureId { get; private set; }
        public int UserId { get; private set; }
    }
}
