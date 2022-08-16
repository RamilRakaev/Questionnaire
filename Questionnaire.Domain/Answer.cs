namespace Questionnaire.Domain
{
    public class AnswerEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int QuestionId { get; set; }
        public QuestionEntity Question { get; set; }
    }
}
