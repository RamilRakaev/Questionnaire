namespace Questionnaire.Domain.Entities
{
    public class PropertyEntity : BaseEntity
    {
        public int QuestionnaireId { get; set; }
        public QuestionnaireEntity Questionnaire { get; set; }

        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public PropertyType Type { get; set; }

        public List<string> Options { get; set; }
    }
}
