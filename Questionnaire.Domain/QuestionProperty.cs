namespace Questionnaire.Domain
{
    public class QuestionProperty
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
