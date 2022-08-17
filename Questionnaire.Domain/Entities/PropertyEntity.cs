namespace Questionnaire.Domain.Entities
{
    public class PropertyEntity : BaseEntity
    {
        public int QuestionnaireId { get; set; }
        public QuestionnaireEntity Questionnaire { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public QuestionType Type { get; set; }

        public string[] Options { get; set; }
    }
}
