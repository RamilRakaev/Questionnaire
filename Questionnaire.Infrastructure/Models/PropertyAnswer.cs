using Questionnaire.Domain.Entities;

namespace Questionnaire.Infrastructure.Models
{
    public class PropertyAnswer
    {
        public Property Property { get; set; }

        public Answer Answer { get; set; }

        public List<PropertyAnswer> PropertyAnswers { get; set; }
    }
}
