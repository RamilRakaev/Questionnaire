namespace Questionnaire.Domain.Entities
{
    public class QuestionnaireEntity : BaseEntity
    {
        public string DisplayName { get; set; }
        public string JsonName { get; set; }

        public List<string> Options { get; set; }

        public List<PropertyEntity> Properties { get; set; }
        public List<AnswerEntity> Answers { get; set; }
    }
}
