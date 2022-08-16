namespace Questionnaire.Domain.Entities
{
    public class QuestionnaireEntity : BaseEntity
    {
        public string DisplayName { get; set; }

        public PropertyEntity[] Properties { get; set; }

        public string[] Options { get; set; }

        public AnswerEntity[] Answers { get; set; }
    }
}
