namespace Questionnaire.Domain
{
    public class QuestionEntity
    {
        public int Id { get; set; }

        public int QuestionnaireId { get; set; }
        public QuestionnaireEntity Questionnaire { get; set; }

        public int QuestionId { get; set; }
        public QuestionEntity SubQuestion { get; set; }

        public List<QuestionProperty> Properties { get; set; }
        public List<AnswerEntity> Answers { get; set; }
    }
}
